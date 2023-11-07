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

namespace Star_Gym
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-SFKEA07;Initial Catalog=GYM Management System;Integrated Security=True");
        SqlCommand com;
        SqlDataReader dr;
      

        private void btnl_Click(object sender, EventArgs e)
        {
            con.Open();

            String a = "SELECT * FROM Login WHERE Username='"+txu.Text+"'";
            com = new SqlCommand(a, con);
            dr = com.ExecuteReader();

            if (txu.Text == "")
            {
                MessageBox.Show("Enter the username");
            }
            else if (txp.Text == "")
            {
                MessageBox.Show("Enter the password");
            }
             else if (dr.Read())
            {
                String Username = dr["Username"].ToString();
                String Position = dr["Position"].ToString();
                String password = dr["Password"].ToString();

                if (txp.Text == password)
                {
                    if (Position == "Receptionist")
                    {
                        MessageBox.Show("Account does not exist");
                        txp.Text = "";
                        txu.Text = "";
                    }
                    else if (Position == "Admin")
                    {
                        Menu c = new Menu();
                        c.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect password");
                    txp.Text = "";
                }
            }

            else
            {
                MessageBox.Show("Check your username");
                txp.Text = "";
                txu.Text = "";
            }

            con.Close();
        }

          private void btne_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Are sure to exit?","Confiremation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 s = new Form2();
            s.Show();
            this.Hide();
        }
    }
}
