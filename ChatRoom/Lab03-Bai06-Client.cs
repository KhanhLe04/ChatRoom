using LAB3.BAI6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class Lab03_Bai06_Client : Form
    {
        public Lab03_Bai06_Client()
        {
            InitializeComponent();
        }
        TcpClient tcpClient;
        Thread clientThread;

        bool connecting = true;
        private delegate void SafeCallDelegate(string username, string data);
        private delegate void SafeParticipantsCallDelegate(string username);
        private void UpdateChatHistorySafeCall(string username, string data)
        {
            if (listMessage.InvokeRequired)
            {
                var method = new SafeCallDelegate(UpdateChatHistorySafeCall);
                listMessage.Invoke(method, new object[] { username, data });
            }
            else
            {
                if (username == null)
                {
                    listMessage.Items.Add(data);
                }
                else
                {
                    listMessage.Items.Add($"{username}: {data}");
                }
            }
        }



        private void UpdateParticipantSafeCall(string username)
        {
            if (listParticipants.InvokeRequired)
            {
                var method = new SafeParticipantsCallDelegate(UpdateParticipantSafeCall);
                listParticipants.Invoke(method, new object[] { username });
            }
            else
            {
                listParticipants.Items.Add(username);
            }
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);
                btnConnect.Enabled = false;

                NetworkStream net_stream = tcpClient.GetStream();
                byte[] message = Encoding.UTF8.GetBytes(txtName.Text);
                net_stream.Write(message, 0, message.Length);
                net_stream.Flush();
                clientThread = new Thread(Receive);
                clientThread.IsBackground = true;
                clientThread.Start();
            }
            catch
            {
                MessageBox.Show("Cannot connect, please start server first !");
            }

        }

        void Receive()
        {
            NetworkStream net_stream = tcpClient.GetStream();
            byte[] data = new byte[1024];
            try
            {
                while (connecting && tcpClient.Connected)
                {

                    int byte_count = net_stream.Read(data, 0, data.Length);
                    string mess = Encoding.UTF8.GetString(data, 0, byte_count);
                    if (mess.StartsWith("NewUser|"))
                    {
                        string newUsername = mess.Substring(8);
                        UpdateParticipantSafeCall(newUsername);

                    }
                    else if (mess.StartsWith("User|"))
                    {
                        string newMess = mess.Substring(5);
                        string[] arrListStr = newMess.Split(':');

                        bool isUserExist = false;
                        foreach (ListViewItem item in listParticipants.Items)
                        {
                            if (item.Text == arrListStr[0])
                            {
                                isUserExist = true;
                                break;
                            }
                        }

                        if (!isUserExist)
                        {
                            UpdateParticipantSafeCall(arrListStr[0]);
                        }

                        UpdateChatHistorySafeCall(arrListStr[0], arrListStr[1]);
                    }
                    else if (mess.StartsWith("Private|"))
                    {
                        UpdateChatHistorySafeCall(null, mess);
                    }
                    if (byte_count == 0)
                    {
                        connecting = false;
                    }
                }
            }
            catch
            {
                tcpClient.Close();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            NetworkStream net_stream = tcpClient.GetStream();
            byte[] message = Encoding.UTF8.GetBytes($"(Text){txtMessage.Text.Trim()}");
            net_stream.Write(message, 0, message.Length);
            UpdateChatHistorySafeCall("Tôi", txtMessage.Text);
            net_stream.Flush();
            txtMessage.Text = string.Empty;



        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            NetworkStream net_stream = tcpClient.GetStream();
            byte[] message = Encoding.UTF8.GetBytes(" disconnected");
            net_stream.Write(message, 0, message.Length);
            clientThread = null;
            tcpClient.Close();
            UpdateChatHistorySafeCall(txtName.Text, "Disconnected !");
            btnConnect.Enabled = true;
        }

        private void listParticipants_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void listParticipants_DoubleClick(object sender, EventArgs e)
        {
            if (listParticipants.SelectedIndices.Count > 0)
            {
                int index = listParticipants.SelectedIndices[0];
                string thiername = listParticipants.Items[index].Text;
                BeginInvoke(new MethodInvoker(() =>
                {
                    Lab03_Bai06_Me meForm = new Lab03_Bai06_Me(thiername, txtName.Text, tcpClient);
                    meForm.Show();

                }));

            }

        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSend.PerformClick();
        }
    }
}