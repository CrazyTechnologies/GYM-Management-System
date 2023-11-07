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
    public partial class Account_edit : Form
    {
        public Account_edit()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Data Source=DESKTOP-SFKEA07;Initial Catalog=GYM Management System;Integrated Security=True");
        SqlCommand com;
        SqlDataReader dr;
        String status;


        public void Clear()
        {
            txu.Text = "";
            txp.Text = "";
            cb.Text = "";
            txu.Enabled = true;
            txp.Enabled = true;
            cb.Enabled = false;
        }
        private void Account_edit_Load(object sender, EventArgs e)
        {
            txu.Enabled = true;
            txp.Enabled = true;
            cb.Enabled = false;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            status = "Edit";
            con.Open();

            String a = "SELECT Position FROM Login WHERE and Password='" + txp.Text + "'";
            com = new SqlCommand(a, con);
            dr = com.ExecuteReader();

            String username = txu.Text;
            String Password = txp.Text;

            if (dr.Read())
            {
                cb.Text = dr["Position"].ToString();

                txu.Enabled = false;
                txp.Enabled = true;
                cb.Enabled = false;
            }
            else if (txu.Text == "")
            {
                MessageBox.Show("Enter the username");
                Clear();
            }
            else if (txp.Text == "")
            {
                MessageBox.Show("Enter the password");
            }
            else
            {
                MessageBox.Show("Rcord does not exist");
                Clear();
            }
            con.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txu.Text == "")
            {
                MessageBox.Show("Select a action");
            }
            else if (txu.Text == "")
            {
                MessageBox.Show("Username can't be empty");
                Clear();
            }
            else if (txp.Text == "")
            {
                MessageBox.Show("Password can't be empty");
            }
            else if (cb.Text == "")
            {
                MessageBox.Show("Position can't be empty");
            }
            else
            {

                con.Open();

                String Sql = "UPDATE Login SET Password ='" + txp.Text + "',Position='" + cb.Text + "' WHERE Username='" + txu.Text + "'";
                com = new SqlCommand(Sql, con);
                com.ExecuteNonQuery();
                MessageBox.Show("Record successfuly saved");
                Clear();
                Form1 sn = new Form1();
                sn.Show();
                this.Hide();
                con.Close();
            }
        }

        private void btnback_Click_1(object sender, EventArgs e)
        {
            Selection_Menu a = new Selection_Menu();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
