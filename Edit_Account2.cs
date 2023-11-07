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
    public partial class Edit_Members2 : Form
    {
        public Edit_Members2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-SFKEA07;Initial Catalog=GYM Management System;Integrated Security=True");
        SqlCommand com;
        SqlDataReader dr;
        string status;

        public void Clear()
        {
            txu.Text = "";
            txp.Text = "";
            cb.Text = "";
            txu.Enabled =true;
            txp.Enabled = true;
            cb.Enabled = false;
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            AccountMenu2 a = new AccountMenu2();
            a.Show();
            this.Hide();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            status = "Edit";
            String Position =cb.Text;
            con.Open();

            String a = "SELECT Position FROM Login WHERE Username='" + txu.Text + "'";
            com = new SqlCommand(a, con);
            dr = com.ExecuteReader();


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

        private void Edit_Members2_Load(object sender, EventArgs e)
        {
            txu.Enabled = true;
            txp.Enabled = true;
            cb.Enabled = false;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
