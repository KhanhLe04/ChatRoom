using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;
using System.Collections;
using System.Security.Cryptography;

namespace LAB3
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        TcpListener tcpServer;
        private Dictionary<string, TcpClient> dic_clients = new Dictionary<string, TcpClient>();
        private delegate void SafeCallDelegate(string username, string message);
        bool listening = true;

        private void UpdateChatHistorySafeCall(string username, string message)
        {
            if (listMessage.InvokeRequired)
            {
                var method = new SafeCallDelegate(UpdateChatHistorySafeCall);
                listMessage.Invoke(method, new object[] { username, message });
            }
            else
            {
                listMessage.Items.Add($"{username}: {message}");
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread listenThread = new Thread(new ThreadStart(Listen));
            listenThread.IsBackground = true;
            listenThread.Start();
            listMessage.Items.Add("Server started ! \r\n" + "Waiting for connections ...");
            btnListen.Enabled = false;

        }
        void Listen()
        {

            tcpServer = new TcpListener(IPAddress.Any, 8080);
            tcpServer.Start();
            try
            {
                while (listening)
                {
                    TcpClient client = tcpServer.AcceptTcpClient();
                    NetworkStream net_stream = client.GetStream();
                    byte[] data = new byte[1024];
                    int byte_count = net_stream.Read(data, 0, data.Length);
                    string username = Encoding.UTF8.GetString(data, 0, byte_count);
                    if (!username.StartsWith("(PrivateMess)") || !username.StartsWith("(Text)"))
                    {
                        if (dic_clients.ContainsKey(username))
                        {
                            byte[] response = Encoding.UTF8.GetBytes("Trùng tên người dùng !");
                            net_stream.Write(response, 0, response.Length);
                            net_stream.Flush();
                            client.Close();
                        }
                        else
                        {
                            UpdateChatHistorySafeCall(username, " has connected !");
                            dic_clients.Add(username, client);
                            Thread receiveClientThread = new Thread(Receive);
                            receiveClientThread.IsBackground = true;
                            receiveClientThread.Start(username);
                            byte[] newUserMessage = Encoding.UTF8.GetBytes($"NewUser|{username}");
                            foreach (TcpClient otherClient in dic_clients.Values)
                            {
                                if (otherClient != client)
                                {
                                    NetworkStream otherStream = otherClient.GetStream();
                                    otherStream.Write(newUserMessage, 0, newUserMessage.Length);
                                    otherStream.Flush();
                                }
                            }

                        }

                    }



                }

            }
            catch
            {
                tcpServer = new TcpListener(IPAddress.Any, 8080);
            }

        }

        void Receive(object obj)
        {
            string username = obj.ToString();
            TcpClient client = dic_clients[username];
            NetworkStream net_stream = client.GetStream();
            byte[] recv = new byte[1024];
            try
            {
                while (listening)
                {
                    int byte_count = net_stream.Read(recv, 0, recv.Length);
                    string mess = System.Text.Encoding.UTF8.GetString(recv, 0, byte_count);
                    SendTCPClientInformation(username, mess, client);

                    UpdateChatHistorySafeCall(username, mess);
                    if (byte_count == 0)
                    {
                        listening = false;
                    }
                }

            }
            catch
            {
                dic_clients.Remove(username);
                client.Close();

            }
        }

        void SendTCPClientInformation(string username, string mess, TcpClient this_client)
        {

            if (mess.Contains("(Text)"))
            {
                byte[] message = Encoding.UTF8.GetBytes($"User|{username}: {mess.Substring(6)}");

                foreach (TcpClient client in dic_clients.Values)
                {
                    if (client != this_client)
                    {
                        NetworkStream net_stream = client.GetStream();
                        net_stream.Write(message, 0, message.Length);
                        net_stream.Flush();
                    }
                }

            }
            if (mess.StartsWith("(PrivateMess)"))
            {
                string[] messSplit = mess.Split('|');
                string thiername = messSplit[1].Trim();
                string message = $"Private|{username}|{messSplit[2]}";
                string message1 = $"ToForm|{username}|{messSplit[2]}";

                foreach (string user in dic_clients.Keys)
                {
                    if (user == thiername)
                    {
                        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                        byte[] messageBytes1 = Encoding.UTF8.GetBytes(message1);

                        TcpClient thierClient = dic_clients[user];
                        NetworkStream netStream = thierClient.GetStream();

                        netStream.Write(messageBytes, 0, messageBytes.Length);
                        netStream.Write(messageBytes1, 0, messageBytes1.Length);
                        netStream.Flush();
                    }
                }
            }



        }


    }




}