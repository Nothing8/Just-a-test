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
    // Ennek az osztálynak lehetne valami tisztességes neve. (pl. LoginForm)
    public partial class Form1 : Form
    {
        //Ez sehol sincs használva.
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


        //Ennek egyszerűenk vissza kall térnie igazzal vagy hamissal. A "ver" változó fölösleges.
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
        
                
            

        //nincs lekezelve a sikertelen bejelentkezés
        private void UserLoad()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16590/");
            HttpResponseMessage response = client.PostAsJsonAsync("api/User/'"+txtUsername.Text+"'/'"+txtPassword.Text+"'",0).Result;
            userSID = response.Content.ReadAsAsync<String>().Result;
            

        }
        

        
        // Ez a függvény fölösleges.
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
            //előbb próbálod betölteni a felhasználót, és csak utána ellenőrzöd le, hogy a felhasználónév és jelszó ki van-e töltve. Ez így jelenleg tetszőleges felhasználónévvel és jelszóval beenged.
            UserLoad();
            Verification();
            if (ver == true) { MessageBox.Show("Sikeres bejelentkezés!"); OpenProgram(); }
        }
    }
}
