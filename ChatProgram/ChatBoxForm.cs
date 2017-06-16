using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace ChatProgram
{
    public partial class ChatBoxForm : Form
    {
        private UserClass actualUser = new UserClass();
        private UserClass chatPartner = new UserClass();

        private List<MessageClass> messageList;

        private int LastMessageCount;
    
        public ChatBoxForm()
        {
            InitializeComponent();
        }

        internal void Build(UserClass actualUser, UserClass chatPartner)
        {
            this.actualUser = actualUser;
            this.chatPartner = chatPartner;
            
            rchChat.Font = new Font("Arial", 14);
            LoadMessages();


            timerForRefresh.Enabled = true;
            timerForRefresh.Start();

            timerToCheckSeen.Enabled = true;
            timerToCheckSeen.Start();
           
        }

        private void refreshChat()
        {
            throw new NotImplementedException();
        }

        private void ChatBoxForm_Load(object sender, EventArgs e)
        {

            this.Text = "Csevegés " + chatPartner.UserName + " felhasználóval!";

        }

        private void LoadMessages()
        {
            rchChat.Text = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16590/");
            HttpResponseMessage response = client.GetAsync("api/Message").Result;
            messageList = response.Content.ReadAsAsync<List<MessageClass>>().Result;
            int MessageCount = messageList.Count;
            for (int i = 0; i < MessageCount; i++)
            {
                if (messageList[i].Sender == actualUser.UserName && messageList[i].Receiver == chatPartner.UserName)
                {
                    if (messageList[i].Seen)
                    {
                        rchChat.Text += "You sent: " + Environment.NewLine + messageList[i].Message + "\u221A" + Environment.NewLine;
                        
                    }
                    else {
                        rchChat.Text += "You sent: " + Environment.NewLine + messageList[i].Message + Environment.NewLine;
                    }
                }
                if (messageList[i].Sender == chatPartner.UserName && messageList[i].Receiver == actualUser.UserName)
                {
                    rchChat.Text += chatPartner.UserName+" sent: " + Environment.NewLine + messageList[i].Message + Environment.NewLine;
                }

            }
            LastMessageCount = MessageCount;

        }
        

        private void rchMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage();

        }

        private void SendMessage()
        {
           
            if (rchMessage.Text != "")
            {
                MessageClass newMessage = new MessageClass() {
                                                                Message = rchMessage.Text,
                                                                Sender = actualUser.UserName,
                                                                Receiver = chatPartner.UserName,
                                                                Seen = false
                                                             };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:16590/");
                HttpResponseMessage response = client.PostAsJsonAsync("api/Message", newMessage).Result;
                
            }

            rchMessage.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshMessages();
             
        }

        private void RefreshMessages()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16590/");
            HttpResponseMessage response = client.GetAsync("api/Message").Result;
            messageList = response.Content.ReadAsAsync<List<MessageClass>>().Result;
            int MessageCount = messageList.Count;
            for (int i = LastMessageCount; i < MessageCount; i++)
            {
                if (messageList[i].Sender == actualUser.UserName && messageList[i].Receiver == chatPartner.UserName)
                    if (messageList[i].Seen)
                    {
                        rchChat.Text += "You sent: " + Environment.NewLine + messageList[i].Message + "\u221A" + Environment.NewLine;

                    }
                    else {
                        rchChat.Text += "You sent: " + Environment.NewLine + messageList[i].Message + Environment.NewLine;
                    }
                if (messageList[i].Sender == chatPartner.UserName && messageList[i].Receiver == actualUser.UserName)
                {
                    rchChat.Text += chatPartner.UserName + " sent: " + Environment.NewLine + messageList[i].Message + Environment.NewLine;
                }

            }
            LastMessageCount = MessageCount;
        }

        private void rchMessage_Enter(object sender, EventArgs e)
        {
            SeenIt();
        }

        private void SeenIt()
        {
            for (int i = 0; i < messageList.Count; i++)
            {
                if (messageList[i].Sender == chatPartner.UserName && messageList[i].Receiver == actualUser.UserName && messageList[i].Seen == false)
                {
                    messageList[i].Seen = true; 
                    MessageSeen(messageList[i]);
                }
            }
        }

        private void MessageSeen(MessageClass update)
        {
            MessageClass updatedMessage = new MessageClass(){
                                                                Message = update.Message,
                                                                Sender = update.Sender,
                                                                Receiver = update.Receiver,
                                                                Seen = update.Seen
                                                            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16590/");
            HttpResponseMessage response = client.PutAsJsonAsync("api/Message/"+update.ID, updatedMessage).Result;
        }

        private void timerToCheckSeen_Tick(object sender, EventArgs e)
        {
            SeenIt();
        }
    }
}
