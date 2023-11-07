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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-SFKEA07;Initial Catalog=GYM Management System;Integrated Security=True");
        SqlCommand com;
        SqlDataReader dr;

        private void btne_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Are you sure to exit?", "Confiremation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == msg)
            {
                Application.Exit();
            }
            else { }
        }

        public void Clear()
        {
            Refresh();
    
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 s = new Form2();
            s.Show();
            this.Hide();
        }

        private void btnl_Click(object sender, EventArgs e)
        {
            

            if (txu.Text == "")
            {
                MessageBox.Show("Enter the username");
                txu.Text = "";
                txp.Text = "";
            }
            else if (txp.Text == "")
            {
                MessageBox.Show("Enter the password");
                txp.Text = "";
            }
            else
            {
                con.Open();
                String a = "SELECT * FROM Login WHERE Username='" + txu.Text + "'";
                com = new SqlCommand(a, con);
                dr = com.ExecuteReader();

                if (dr.Read())
                {
                    String Username = dr["Username"].ToString();
                    String Position = dr["Position"].ToString();
                    String password = dr["Password"].ToString();

                    if (txp.Text == password)
                    {
                        if (Position == "Receptionist")
                        {
                            Menu2 s = new Menu2();
                            s.Show();
                            this.Hide();
                        }
                        else if (Position == "Admin")
                        {
                            MessageBox.Show("Account doesn't exist");
                            txp.Text = "";
                            txu.Text = "";
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

          
        }
      
    }
   
}
