using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    public partial class CreateWorkout : Form
    {
        public CreateWorkout()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var th = new Thread(() => Application.Run(new Account()));
            th.SetApartmentState(ApartmentState.STA); // Deprecation Fix
            th.Start();
            this.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
           



            //UPDATE CREATED FROM REGISTRATION COW WITH USED USERNAME FROM REGISTER
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Days SET Ponedelnik = @Ponedelnik, Vtornik = @Vtornik, Srqda = @Srqda, Chetvurtuk = @Chetvurtuk, Petuk = @Petuk,Subota = @Subota, Nedelq = @Nedelq Where Username = @Username and Password = @Password", con);

            cmd.Parameters.AddWithValue("@Password", LoginScreen.password);
            cmd.Parameters.AddWithValue("@Username", LoginScreen.username);
            cmd.Parameters.AddWithValue("@Ponedelnik", comboBox1.Text + "  " + comboBox2.Text);
            cmd.Parameters.AddWithValue("@Vtornik", comboBox3.Text + "  " + comboBox4.Text);
            cmd.Parameters.AddWithValue("@Srqda", comboBox5.Text + "  " + comboBox6.Text);
            cmd.Parameters.AddWithValue("@Chetvurtuk", comboBox7.Text + "  " + comboBox8.Text);
            cmd.Parameters.AddWithValue("@Petuk", comboBox9.Text + "  " + comboBox10.Text);
            cmd.Parameters.AddWithValue("@Subota", comboBox11.Text + "  " + comboBox12.Text);
            cmd.Parameters.AddWithValue("@Nedelq", comboBox13.Text + "  " + comboBox14.Text);



            cmd.ExecuteNonQuery();

            Thread.Sleep(500);

            MessageBox.Show("Succsesfully created workout");

            var th = new Thread(() => Application.Run(new Account()));
            th.SetApartmentState(ApartmentState.STA); // Deprecation Fix
            th.Start();
            this.Close();



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 7)
            {
                comboBox2.Text = "";
                comboBox2.Enabled = false;
                
            }
            else comboBox2.Enabled = true;


            

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 7)
            {
                comboBox3.Enabled = false;
            }
            else comboBox3.Enabled = true;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == 7)
            {
                comboBox5.Enabled = false;
            }
            else comboBox5.Enabled = true;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == 7)
            {
                comboBox7.Enabled = false;
            }
            else comboBox7.Enabled = true;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.SelectedIndex == 7)
            {
                comboBox9.Enabled = false;
            }
            else comboBox9.Enabled = true;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.SelectedIndex == 7)
            {
                comboBox11.Enabled = false;
            }
            else comboBox11.Enabled = true;
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox14.SelectedIndex == 7)
            {
                comboBox13.Enabled = false;
            }
            else comboBox3.Enabled = true;
        }
 
    }
}
