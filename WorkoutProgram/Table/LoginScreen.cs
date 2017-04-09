using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;

namespace Table
{
    public partial class LoginScreen : Form
    {
        public static string username;
        public static string password;


        public LoginScreen()
        {
            InitializeComponent();


            //Start program focused on USERNAME 
            this.ActiveControl = textBox1;
            textBox1.Focus();


        }

        // button LOGIN click
        private void button1_Click(object sender, EventArgs e)
        {

            //get username and password 
            username = textBox1.Text;
            password = textBox2.Text;



            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from Login where username ='" + textBox1.Text.Trim() + "'and password ='" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if (dtb.Rows.Count == 1)
            {
        

                Thread.Sleep(500);
                
                //this.Hide();
                //Form2 f2 = new Form2();
                //f2.Show();

                var th = new Thread(() => Application.Run(new Account()));
                th.SetApartmentState(ApartmentState.STA); // Deprecation Fix
                th.Start();

                this.Close();



            }
            else
                MessageBox.Show("WRONG USERNAME OR PASSWORD");


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Create an instance of the TextBox control.
           
            // Set the maximum length of text in the control to eight.
            textBox2.MaxLength = 16;

            // Assign the asterisk to be the password character.
            textBox2.PasswordChar = '*';

            // Change all text entered to be lowercase.
            textBox2.CharacterCasing = CharacterCasing.Lower;
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var th = new Thread(() => Application.Run(new register()));
            th.SetApartmentState(ApartmentState.STA); // Deprecation Fix
            th.Start();

        }

        //Enter press to go to password 
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();

                //disable the "beep" sound
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        //Enter press to perform click "LOGIN" button 
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();

                //disable the "beep" sound
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
