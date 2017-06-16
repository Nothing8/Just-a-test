using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatProgram
{
    public partial class ChatForm : Form
    {
        private UserClass actualUser = new UserClass();
        private UserClass chatPartner = new UserClass();
        private List<UserClass> contactList = new List<UserClass>();

        public ChatForm()
        {
            InitializeComponent();
        }

        internal void Build(List<UserClass> contactList, UserClass actualUser)
        {
            this.actualUser = actualUser;
            this.contactList = contactList;
            
            for (int i = 0; i < contactList.Count; i++)
            {
                lstContacts.Items.Add(contactList[i].UserName);
            }
        }

        

        private void btnChatting_Click(object sender, EventArgs e)
        {
            SelectPartner();
            ChatBoxForm chatBox = new ChatBoxForm();
            chatBox.Build(actualUser,chatPartner);
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
                    if (contactList[i].UserName == selected)
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

            Form1 logIn = new Form1();
            this.Hide();
            logIn.ShowDialog();
            this.Close();
        }
    }
}
