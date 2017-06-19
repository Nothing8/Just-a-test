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
        

        private string userSID;
        private string chatPartner;
        private string currentUser;

        private List<MessageClass> messageList;

        private int LastMessageCount;
    
        public ChatBoxForm()
        {
            InitializeComponent();
        }

        internal void Build(string userSID, string chatPartner)
        {
            
            this.userSID = userSID;
            this.chatPartner = chatPartner;
            UserGet();

            rchChat.Font = new Font("Arial", 14);
            LoadMessages();


            timerForRefresh.Enabled = true;
            timerForRefresh.Start();

            timerToCheckSeen.Enabled = true;
            timerToCheckSeen.Start();
           
        }

        private void UserGet()
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16590/");
            HttpResponseMessage response = client.GetAsync("api/User/'" + userSID + "'/0/1").Result;
            currentUser = response.Content.ReadAsAsync<String>().Result;
            
        }

        private void refreshChat()
        {
            throw new NotImplementedException();
        }

        private void ChatBoxForm_Load(object sender, EventArgs e)
        {

            this.Text = "Csevegés " + chatPartner + " felhasználóval!";




        }

        private void LoadMessages()
        {
            rchChat.Text = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16590/");
            HttpResponseMessage response = client.GetAsync("api/Message/'" + userSID + "'/'" + currentUser + "'/'" + chatPartner + "'/0").Result;
            messageList = response.Content.ReadAsAsync<List<MessageClass>>().Result;
            int MessageCount = messageList.Count;

            for (int i = 0; i < MessageCount; i++)
            {
                if (messageList[i].Sender == currentUser)
                {
                    if (messageList[i].Seen)
                    {
                        rchChat.Text += "You sent: " + Environment.NewLine + messageList[i].Message + "\u221A" + Environment.NewLine;

                    }
                    else {
                        rchChat.Text += "You sent: " + Environment.NewLine + messageList[i].Message + Environment.NewLine;
                    }
                }
                if (messageList[i].Sender == chatPartner)
                {
                    rchChat.Text += chatPartner + " sent: " + Environment.NewLine + messageList[i].Message + Environment.NewLine;
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
                                                                Sender = currentUser,
                                                                Receiver = chatPartner,
                                                                Seen = false
                                                             };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:16590/");
                HttpResponseMessage response = client.PostAsJsonAsync("api/Message/'"+userSID+"'",newMessage).Result;
                
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
            HttpResponseMessage response = client.GetAsync("api/Message/'" + userSID + "'/'" + currentUser +"'/'" + chatPartner + "'/0").Result;
            messageList = response.Content.ReadAsAsync<List<MessageClass>>().Result;
            int MessageCount = messageList.Count;
            for (int i = LastMessageCount; i < MessageCount; i++)
            {
                if (messageList[i].Sender == currentUser)
                    if (messageList[i].Seen)
                    {
                        rchChat.Text += "You sent: " + Environment.NewLine + messageList[i].Message + "\u221A" + Environment.NewLine;

                    }
                    else {
                        rchChat.Text += "You sent: " + Environment.NewLine + messageList[i].Message + Environment.NewLine;
                    }
                if (messageList[i].Sender == chatPartner)
                {
                    rchChat.Text += chatPartner + " sent: " + Environment.NewLine + messageList[i].Message + Environment.NewLine;
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
                if (messageList[i].Sender == chatPartner && messageList[i].Seen == false)
                {
                    messageList[i].Seen = true; 
                    MessageSeen(messageList[i]);
                }
            }
        }

        private void MessageSeen(MessageClass update)
        { 
            MessageClass updatedMessage = new MessageClass(){
                                                                Seen = update.Seen
                                                            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16590/");
            HttpResponseMessage response = client.PutAsJsonAsync("api/Message/"+update.ID+"/'"+userSID+"'", updatedMessage).Result;
        }

        private void timerToCheckSeen_Tick(object sender, EventArgs e)
        {
            SeenIt();
        }
    }
}
