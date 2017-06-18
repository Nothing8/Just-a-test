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
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace ChatProgram
{
    public partial class ChatForm : Form
    {
        private UserClass actualUser = new UserClass();
        private List<String> contactList = new List<String>();
        private string userSID;
        private string chatPartner;

        public ChatForm()
        {
            InitializeComponent();
        }

        internal void Build(string userSID)
        {
            this.userSID = userSID;

            ContactsLoad();           
            for (int i = 0; i < contactList.Count; i++)
            {
                lstContacts.Items.Add(contactList[i]);
            }
        }

        private void ContactsLoad()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16590/");
            HttpResponseMessage response = client.GetAsync("api/User/'"+userSID+"'/0").Result;
            contactList = response.Content.ReadAsAsync<List<String>>().Result;
        }

        private void btnChatting_Click(object sender, EventArgs e)
        {
            SelectPartner();
            ChatBoxForm chatBox = new ChatBoxForm();
            chatBox.Build(userSID,chatPartner);
            this.Hide();
            chatBox.ShowDialog();
            this.Show();
        }

        

        private void SelectPartner()
        {
            if (lstContacts.SelectedIndex != -1)
            {
                
                string selected = lstContacts.SelectedItem.ToString();
                for (int i = 0; i < contactList.Count; i++)
                {
                    if (contactList[i] == selected)
                    {
                        chatPartner = contactList[i];
                    }
                }
            }
            else 
            {
                MessageBox.Show("Kérem válasszon valakit akivel chatelni szeretne!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Eraser();
            Form1 logIn = new Form1();
            this.Hide();
            logIn.ShowDialog();
            this.Close();

        }

        private void Eraser()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16590/");
            HttpResponseMessage response = client.DeleteAsync("api/User/'" + userSID + "'/0").Result;
        }
    }
}
