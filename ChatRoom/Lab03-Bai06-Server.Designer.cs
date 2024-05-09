namespace LAB3
{
    partial class Lab03_Bai06_Server
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
            btnListen = new Button();
            listMessage = new ListView();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.Location = new Point(546, 12);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(153, 29);
            btnListen.TabIndex = 1;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // listMessage
            // 
            listMessage.Location = new Point(12, 57);
            listMessage.Name = "listMessage";
            listMessage.Size = new Size(687, 352);
            listMessage.TabIndex = 2;
            listMessage.UseCompatibleStateImageBehavior = false;
            listMessage.View = View.List;
            // 
            // Lab03_Bai06_Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 419);
            Controls.Add(listMessage);
            Controls.Add(btnListen);
            Name = "Lab03_Bai06_Server";
            Text = "Chat Server";
            ResumeLayout(false);
        }

        #endregion
        private Button btnListen;
        private ListView listMessage;
    }
}