using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
   

    public partial class Account : Form
    {
        DataSet ds = new DataSet();
        public static string nickname;
        public static byte[] avatarImage;
        public static object CheckPic;


        public  Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var th = new Thread(() => Application.Run(new LoginScreen()));
            th.SetApartmentState(ApartmentState.STA); // Deprecation Fix
            th.Start();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private  void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
 
        }

        private void Account_Load(object sender, EventArgs e)
        {

       

            textBox1.Hide();
           
            label2.Text = LoginScreen.username;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            //READ THE CHANGED NAME in ACCOUNT INFO 
            SqlCommand command = new SqlCommand("SELECT * from Login WHERE Username = @Username and Password = @Password ", con);

            command.Parameters.AddWithValue("@Password", LoginScreen.password);
            command.Parameters.AddWithValue("@Username", LoginScreen.username);


            SqlDataReader reader = command.ExecuteReader();

           
            while (reader.Read())
            {

              
                label2.Text = reader["ChangedName"].ToString();
                CheckPic = reader["Avatar"].ToString();
               


            }
            reader.Close();


            //LOAD ACCOUNT IMAGE (AVATAR)

            string query = "Select * from Login where username ='" + LoginScreen.username + "'and password ='" + LoginScreen.password + "'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand(query, con));

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count == 1)
            {
                
                Byte[] data = new Byte[0];
                data = (Byte[])(dataSet.Tables[0].Rows[0]["Avatar"]);
                MemoryStream mem = new MemoryStream(data);
                
                pbpic.Image = Image.FromStream(mem);
            
            }

            //LOAD WORKOUT
            SqlCommand cmd = new SqlCommand("SELECT * from Days WHERE Username = @Username and Password = @Password ", con);


            cmd.Parameters.AddWithValue("@Password", LoginScreen.password);
            cmd.Parameters.AddWithValue("@Username", LoginScreen.username);
            

            SqlDataReader rd = cmd.ExecuteReader();

            


            while (rd.Read())
            {

               


                label3.Text = rd["Ponedelnik"].ToString();
                label5.Text = rd["Vtornik"].ToString();
                label11.Text = rd["Srqda"].ToString();
                label12.Text = rd["Chetvurtuk"].ToString();
                label13.Text = rd["Petuk"].ToString();
                label14.Text = rd["Subota"].ToString();
                label15.Text = rd["Nedelq"].ToString();

            }

        

        }

     

        private void changeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Hide();
            textBox1.Show();
            textBox1.Text = label2.Text;
            textBox1.Focus();

           
           


        }


        // ENTER TO INSERT NEW NAME IN ACC
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Login SET ChangedName = @changedName where Username = @Username and Password = @Password", con);


                cmd.Parameters.AddWithValue("@Username", LoginScreen.username);
                cmd.Parameters.AddWithValue("@Password", LoginScreen.password);
                cmd.Parameters.AddWithValue("@ChangedName", textBox1.Text);
                cmd.ExecuteNonQuery();


                // show changed name after press ENTER key
                label2.Text = textBox1.Text;
                textBox1.Hide();
                label2.Show();




            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();

            var th = new Thread(() => Application.Run(new LoginScreen()));
            th.SetApartmentState(ApartmentState.STA); // Deprecation Fix
            th.Start();

        }

        //change the AVATAR button form MENU ACCOUNT
        private void changeAvatarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Profile image change
            opbl.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            DialogResult res = opbl.ShowDialog();
            if (res == DialogResult.OK)
            {
                pbpic.Image = Image.FromFile(opbl.FileName);
            }
            //RECORD IMAGE LOACATION IN TABLE "LOGIN" - columm Avatar

            Image img = Image.FromFile(opbl.FileName);
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }

            avatarImage = arr;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Login SET Avatar = @Avatar Where Username = @Username and Password = @Password",con);

            cmd.Parameters.AddWithValue("@Avatar",arr);
            cmd.Parameters.AddWithValue("@Username", LoginScreen.username);
            cmd.Parameters.AddWithValue("@Password", LoginScreen.password);

            cmd.ExecuteNonQuery();
            cmd.ExecuteScalar();

            // byte[] img = reader["Avatar"];

            


        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            var th = new Thread(() => Application.Run(new CreateWorkout()));
            th.SetApartmentState(ApartmentState.STA); // Deprecation Fix
            th.Start();
            this.Close();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
          


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
