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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-SFKEA07;Initial Catalog=GYM Management System;Integrated Security=True");
        SqlCommand com;
        SqlDataReader dr;
        String status;

        public void Clear()
        {
            cb.Text = "";
            txp.Text = "";
            txu.Text = "";
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Are you sure to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Selection_Menu s = new Selection_Menu();
            s.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txu.Text == "")
            {
                MessageBox.Show("Username can't be empty");
            }
            else if (txp.Text == "")
            {
                MessageBox.Show("Passwordcan't be empty");
            }
           else if (cb.Text == "")
            {
                MessageBox.Show("Position can't be empty");
            }
            else
            {
                con.Open();
                String a = "SELECT Username FROM Login WHERE Username='" + txu.Text + "' ";
                com = new SqlCommand(a, con);
                dr = com.ExecuteReader();
             

                if (dr.Read())
                {
                    MessageBox.Show("Please try in another name");
                    Clear();
                }
                else
                {
                    con.Close();
                    con.Open();
                    String Sql = "INSERT INTO Login (Username,Password,Position)VALUES('" + txu.Text + "','" + txp.Text + "','" + cb.Text + "')";
                    com = new SqlCommand(Sql, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Record successfuly saved");
                    Clear();
                }
            }

                con.Close();
        }
    }
}
