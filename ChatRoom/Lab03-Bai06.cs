using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class Lab03_Bai06 : Form
    {
        public Lab03_Bai06()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Lab03_Bai06_Client client = new Lab03_Bai06_Client();
            client.Show();

        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Lab03_Bai06_Server server = new Lab03_Bai06_Server();
            server.Show();
        }

        private void Lab03_Bai06_Load(object sender, EventArgs e)
        {

        }

        private void Lab03_Bai06_FormClosed(object sender, FormClosedEventArgs e)
        {
            Lab03_Bai06 mainform = new Lab03_Bai06();
            mainform.Show();
        }
    }
}
