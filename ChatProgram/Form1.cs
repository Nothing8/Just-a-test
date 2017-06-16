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
    public partial class Form1 : Form
    {
        static List<UserClass> userlist = new List<UserClass>();
        private UserClass actualUser = new UserClass();

        private bool ver = new bool();
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Verification();
            if (ver == true) { OpenProgram(); }
        }

        private void OpenProgram()
        {
            List<UserClass> contactList = new List<UserClass>();
            Listofcontacts(contactList);
            
            ChatForm menuForm = new ChatForm();
            this.Hide();
            menuForm.Build(contactList,actualUser);
            menuForm.ShowDialog();
            this.Show();
            this.Close();
            
        }

        private void Listofcontacts(List<UserClass> contactList)
        {
            for (int i = 0; i < userlist.Count; i++)
            {
                if (userlist[i] != actualUser)
                { contactList.Add(userlist[i]); }
            }
        }

        private void Verification()
        {
    
            if (txtUsername.Text == "" && txtPassword.Text == "") { MessageBox.Show("Kérem adja meg az e-mail címét és a jelszavát!"); ver = false; }
            else {
                if (txtUsername.Text == "") { MessageBox.Show("Kérem adja meg az e-mail címét!"); ver = false; }
                else {
                    if (txtPassword.Text == "") { MessageBox.Show("Kérem adja meg a jelszavát!"); ver = false; }
                    else {
                        int hiba = 0;
                        for (int i = 0; i < userlist.Count; i++)
                            {
                                if (userlist[i].UserName == txtUsername.Text && userlist[i].Password == txtPassword.Text)
                                {
                                    actualUser = userlist[i];
                                    hiba++;
                                    ver = true;    
                                } else { if (hiba == userlist.Count) { MessageBox.Show("Hibás bejelentkezés!", "Kérem adjon meg egy már regisztrált e-mail címet és a hozzá tartozó jelszavat!"); ver = false; } }
                            }
                         }
                    }
                }
            }
        

        private void UserLoad()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16590/");
            HttpResponseMessage response = client.GetAsync("api/User").Result;
            userlist = response.Content.ReadAsAsync<List<UserClass>>().Result;
        


        

        private void Form1_Load(object sender, EventArgs e)
        {
            UserLoad();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Verification();
                if (ver==true) { OpenProgram(); }
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Verification();
                if (ver == true) { OpenProgram(); }
            }
        }
    }
}
