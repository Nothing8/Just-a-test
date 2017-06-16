namespace ChatProgram
{
    partial class ChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lstContacts = new System.Windows.Forms.ListBox();
            this.btnChatting = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Elérhető felhasználók:";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.MintCream;
            this.btnExit.Location = new System.Drawing.Point(180, 237);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Kilépés";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lstContacts
            // 
            this.lstContacts.BackColor = System.Drawing.SystemColors.Menu;
            this.lstContacts.FormattingEnabled = true;
            this.lstContacts.Location = new System.Drawing.Point(13, 35);
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(152, 225);
            this.lstContacts.TabIndex = 3;
            // 
            // btnChatting
            // 
            this.btnChatting.BackColor = System.Drawing.Color.MintCream;
            this.btnChatting.Location = new System.Drawing.Point(180, 35);
            this.btnChatting.Name = "btnChatting";
            this.btnChatting.Size = new System.Drawing.Size(91, 68);
            this.btnChatting.TabIndex = 4;
            this.btnChatting.Text = "Csevegés!";
            this.btnChatting.UseVisualStyleBackColor = false;
            this.btnChatting.Click += new System.EventHandler(this.btnChatting_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.MintCream;
            this.btnLogout.Location = new System.Drawing.Point(180, 208);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(91, 23);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Kijelentkezés";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(290, 275);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnChatting);
            this.Controls.Add(this.lstContacts);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lstContacts;
        private System.Windows.Forms.Button btnChatting;
        private System.Windows.Forms.Button btnLogout;
    }
}