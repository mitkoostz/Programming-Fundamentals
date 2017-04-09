using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;
using System.IO;

namespace Table
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {

                Image img = Image.FromFile(@"C:\Users\root\Desktop\profile.png");
                byte[] arr;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    arr = ms.ToArray();
                }

                //CREATE THE ACCOUNT INFO IN LOGIN TABLE
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Login (Username,Password,ChangedName,Avatar) VALUES (@Username,@Password,@ChangedName,@Avatar)", con);

                cmd.Parameters.Add("@Username", textBox1.Text);

                cmd.Parameters.Add("@Password", textBox2.Text);

                cmd.Parameters.AddWithValue("@ChangedName", textBox1.Text);

                cmd.Parameters.AddWithValue("@Avatar", arr);



                cmd.ExecuteNonQuery();

                //CREATE THE USERNAME IN DAYS 
                SqlCommand command = new SqlCommand("INSERT INTO Days (Username,Password) VALUES (@Username,@Password)", con);

                command.Parameters.AddWithValue("@Username", textBox1.Text);
                command.Parameters.AddWithValue("@Password", textBox2.Text);

                command.ExecuteNonQuery();

                Thread.Sleep(400);
                MessageBox.Show("successfully registered");

            }
            else
            {
                MessageBox.Show("incorrect repeated password");
            }

            this.Close();

        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                //disable the "beep" sound
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();

                //disable the "beep" sound
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();

                //disable the "beep" sound
                e.Handled = e.SuppressKeyPress = true;
            }

        }
    }
}
