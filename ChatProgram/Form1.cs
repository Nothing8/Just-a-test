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

        private string userSID = "";

        private bool ver = new bool();
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthplusVer();
        }

        private void OpenProgram()
        { 
            ChatForm menuForm = new ChatForm();
            this.Hide();
            menuForm.Build(userSID);
            menuForm.ShowDialog();
            this.Show();
            this.Close();
            
        }


        private void Verification()
        {

            if (txtUsername.Text == "" && txtPassword.Text == "") { MessageBox.Show("Kérem adja meg az e-mail címét és a jelszavát!"); ver = false; }
            else {
                if (txtUsername.Text == "") { MessageBox.Show("Kérem adja meg az e-mail címét!"); ver = false; }
                else {
                    if (txtPassword.Text == "") { MessageBox.Show("Kérem adja meg a jelszavát!"); ver = false; }
                    else 

                        if (userSID != "")
                        {
                            ver = true;
                        }
                    }
                }
            }
        
                
            


        private void UserLoad()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16590/");
            HttpResponseMessage response = client.PostAsJsonAsync("api/User/'"+txtUsername.Text+"'/'"+txtPassword.Text+"'",0).Result;
            userSID = response.Content.ReadAsAsync<String>().Result;
            

        }
        

        

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AuthplusVer();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AuthplusVer();
            }
        }

        private void AuthplusVer()
        {
            UserLoad();
            Verification();
            if (ver == true) { MessageBox.Show("Sikeres bejelentkezés!"); OpenProgram(); }
        }
    }
}
