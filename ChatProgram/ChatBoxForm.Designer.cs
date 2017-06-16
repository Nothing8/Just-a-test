namespace ChatProgram
{
    partial class ChatBoxForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatBoxForm));
            this.rchChat = new System.Windows.Forms.RichTextBox();
            this.rchMessage = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timerForRefresh = new System.Windows.Forms.Timer(this.components);
            this.timerToCheckSeen = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // rchChat
            // 
            this.rchChat.BackColor = System.Drawing.SystemColors.Menu;
            this.rchChat.Location = new System.Drawing.Point(13, 24);
            this.rchChat.Name = "rchChat";
            this.rchChat.ReadOnly = true;
            this.rchChat.Size = new System.Drawing.Size(310, 234);
            this.rchChat.TabIndex = 0;
            this.rchChat.Text = "";
            // 
            // rchMessage
            // 
            this.rchMessage.Location = new System.Drawing.Point(13, 265);
            this.rchMessage.MaxLength = 1000;
            this.rchMessage.Name = "rchMessage";
            this.rchMessage.Size = new System.Drawing.Size(310, 40);
            this.rchMessage.TabIndex = 1;
            this.rchMessage.Text = "";
            this.rchMessage.Enter += new System.EventHandler(this.rchMessage_Enter);
            this.rchMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rchMessage_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MintCream;
            this.button1.Location = new System.Drawing.Point(197, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Küldés";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerForRefresh
            // 
            this.timerForRefresh.Interval = 1000;
            this.timerForRefresh.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerToCheckSeen
            // 
            this.timerToCheckSeen.Interval = 5000;
            this.timerToCheckSeen.Tick += new System.EventHandler(this.timerToCheckSeen_Tick);
            // 
            // ChatBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(335, 349);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rchMessage);
            this.Controls.Add(this.rchChat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatBoxForm";
            this.Text = "CsevegesForm";
            this.Load += new System.EventHandler(this.ChatBoxForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchMessage;
        private System.Windows.Forms.RichTextBox rchChat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerForRefresh;
        private System.Windows.Forms.Timer timerToCheckSeen;
    }
}