namespace LAB3.BAI6
{
    partial class Lab03_Bai06_Me
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
            listMessage = new ListView();
            txtMessage = new TextBox();
            btnSend = new Button();
            btnExit = new Button();
            labelInfo = new Label();
            SuspendLayout();
            // 
            // listMessage
            // 
            listMessage.Location = new Point(12, 55);
            listMessage.Name = "listMessage";
            listMessage.Size = new Size(776, 300);
            listMessage.TabIndex = 0;
            listMessage.UseCompatibleStateImageBehavior = false;
            listMessage.View = View.List;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 363);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(576, 27);
            txtMessage.TabIndex = 1;
            txtMessage.KeyDown += txtMessage_KeyDown;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(594, 363);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 2;
            btnSend.Text = "SEND";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(694, 409);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 3;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelInfo.Location = new Point(12, 9);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(120, 35);
            labelInfo.TabIndex = 4;
            labelInfo.Text = "labelInfo";
            // 
            // Lab03_Bai06_Me
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelInfo);
            Controls.Add(btnExit);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(listMessage);
            Name = "Lab03_Bai06_Me";
            Text = "Me";
            Load += Lab03_Bai06_Me_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listMessage;
        private TextBox txtMessage;
        private Button btnSend;
        private Button btnExit;
        private Label labelInfo;
    }
}