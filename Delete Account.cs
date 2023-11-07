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
    public partial class Delete_Account : Form
    {
        public Delete_Account()
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

        private void btnback_Click(object sender, EventArgs e)
        {
            Selection_Menu a = new Selection_Menu();
            a.Show();
            this.Hide();
        }

        private void Delete_Account_Load(object sender, EventArgs e)
        {
            txu.Enabled = true;
            txp.Enabled = true;
            cb.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txu.Text == "")
            {
                MessageBox.Show("Enter the username");
            }
            else
            {
                con.Open();
                String a = "SELECT Position FROM Login WHERE Username='" + txu.Text + "' and Password='" + txp.Text + "'";
                com = new SqlCommand(a, con);
                dr = com.ExecuteReader();


                if (dr.Read())
                {
                    cb.Text = dr["Position"].ToString();
                    txu.Enabled = false;
                    txp.Enabled = false;
                    cb.Enabled = false;

                    DialogResult msg = MessageBox.Show("Are you sure to delete?", "Confiremation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        con.Close();
                        con.Open();
                        String sqla = "DELETE  FROM Login WHERE Username='" + txu.Text + "'";
                        com = new SqlCommand(sqla, con);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Record delete succssessfully");
                        Clear();
                        Form1 sn = new Form1();
                        sn.Show();
                        this.Hide();
                       
                    }
                    else
                    {
                        Clear();
                    }
                }
                else if (txu.Text == "")
                {
                    MessageBox.Show("Enter the username");
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
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
