namespace LAB3
{
    partial class Lab03_Bai06_Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            listParticipants = new ListView();
            label2 = new Label();
            txtName = new TextBox();
            btnConnect = new Button();
            label3 = new Label();
            txtMessage = new TextBox();
            btnSend = new Button();
            btnDisconnect = new Button();
            listMessage = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(604, 12);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 1;
            label1.Text = "Participant(s)";
            // 
            // listParticipants
            // 
            listParticipants.Location = new Point(604, 35);
            listParticipants.Name = "listParticipants";
            listParticipants.Size = new Size(120, 240);
            listParticipants.TabIndex = 2;
            listParticipants.UseCompatibleStateImageBehavior = false;
            listParticipants.View = View.List;
            listParticipants.SelectedIndexChanged += listParticipants_SelectedIndexChanged;
            listParticipants.DoubleClick += listParticipants_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 278);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 3;
            label2.Text = "Your name";
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 301);
            txtName.Name = "txtName";
            txtName.Size = new Size(179, 27);
            txtName.TabIndex = 4;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(216, 300);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(108, 29);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 348);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 6;
            label3.Text = "Message";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 371);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(486, 27);
            txtMessage.TabIndex = 7;
            txtMessage.KeyDown += txtMessage_KeyDown;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(504, 369);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 8;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(633, 370);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(94, 29);
            btnDisconnect.TabIndex = 9;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // listMessage
            // 
            listMessage.Location = new Point(12, 9);
            listMessage.Name = "listMessage";
            listMessage.Size = new Size(586, 266);
            listMessage.TabIndex = 10;
            listMessage.UseCompatibleStateImageBehavior = false;
            listMessage.View = View.List;
            // 
            // Lab03_Bai06_Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 406);
            Controls.Add(listMessage);
            Controls.Add(btnDisconnect);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(label3);
            Controls.Add(btnConnect);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(listParticipants);
            Controls.Add(label1);
            Name = "Lab03_Bai06_Client";
            Text = "Chat Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ListView listParticipants;
        private Label label2;
        private TextBox txtName;
        private Button btnConnect;
        private Label label3;
        private TextBox txtMessage;
        private Button btnSend;
        private Button btnDisconnect;
        private ListView listMessage;
    }
}