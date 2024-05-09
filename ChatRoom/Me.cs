using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace LAB3.BAI6
{
    public partial class Me : Form
    {
        public Me()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            clientThread = new Thread(Receive);
            clientThread.IsBackground = true;
            clientThread.Start();

        }
        public Me(string sentThierName, string sentMyName, TcpClient sentTcpClient)
        {
            InitializeComponent();
            tcpClient = sentTcpClient;
            thiername = sentThierName;
            myname = sentMyName;
            CheckForIllegalCrossThreadCalls = false;
            clientThread = new Thread(Receive);
            clientThread.IsBackground = true;
            clientThread.Start();
        }
        Thread clientThread;
        bool connecting = true;
        private TcpClient tcpClient;
        private string thiername;
        private string myname;
        private delegate void SafeCallDelegate(string username, string data);

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

        private void btnSend_Click(object sender, EventArgs e)
        {
            UpdateChatHistorySafeCall("Tôi", txtMessage.Text);
            NetworkStream net_stream = tcpClient.GetStream();
            byte[] message = Encoding.UTF8.GetBytes($"(PrivateMess)|{thiername}|{txtMessage.Text}");
            net_stream.Write(message, 0, message.Length);
            net_stream.Flush();
            txtMessage.Text = String.Empty;


        }
        private void Receive()
        {
            NetworkStream net_stream = tcpClient.GetStream();
            byte[] data = new byte[1024];
            try
            {
                while (connecting && tcpClient.Connected)
                {
                    int byte_count = net_stream.Read(data, 0, data.Length);
                    string mess = Encoding.UTF8.GetString(data, 0, byte_count);
                    if (mess.StartsWith("ToForm|"))
                    {
                        string[] messageParts = mess.Split('|');
                        string sender = messageParts[1];
                        string message = messageParts[2];
                        UpdateChatHistorySafeCall(sender, message);
                    }
                }
            }
            catch
            {
                tcpClient.Close();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Lab03_Bai06_Me_Load(object sender, EventArgs e)
        {
            labelInfo.Text = $"{myname} to {thiername}";


        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSend.PerformClick();
        }
    }
}