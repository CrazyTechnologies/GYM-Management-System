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
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
        }



        SqlConnection con = new SqlConnection("Data Source=DESKTOP-SFKEA07;Initial Catalog=GYM Management System;Integrated Security=True");
        SqlCommand com;
        SqlDataReader dr;
        String status;

        public void Clear()
        {
            txs.Text = "";
            txav.Text = "";
            txn.Text = "";
            txna.Text = "";
            txc.Text = "";
            txd.Text = "";
            txn.Enabled = true;
            txna.Enabled = false;
            txav.Enabled = false;
            txc.Enabled = false;
            txd.Enabled = false;
    }

        public void loadequipment()
        {
            con.Open();
            string sql = "SELECT * FROM Equipment ";
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();

            LV.Items.Clear();

            while (dr.Read())
            {
                ListViewItem Equipment = new ListViewItem(dr["Equipment_No"].ToString());
                Equipment.SubItems.Add(dr["Equipment_Name"].ToString());
                Equipment.SubItems.Add(dr["Available_Branch"].ToString());
                Equipment.SubItems.Add(dr["Coast"].ToString());
                Equipment.SubItems.Add(dr["Description"].ToString());

                LV.Items.Add(Equipment);
            }
            con.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Menu a = new Menu();
            a.Show();
            this.Hide();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            status = "Search";
            con.Open();

            String sql = ("SELECT * FROM Equipment WHERE Equipment_NO='" + txn.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                txs.Text = "";
                txn.Text = dr["Equipment_NO"].ToString();
                txna.Text = dr["Equipment_Name"].ToString();
                txav.Text = dr["Available_Branch"].ToString();
                txd.Text = dr["Description"].ToString();
                txc.Text = dr["Coast"].ToString();


                txn.Text = "";
                txna.Text = "";
                txav.Text = "";
                txd.Text = "";
                txc.Text = "";
            }
            else if (txs.Text == "")
            {
                MessageBox.Show("Enter the equipment number");
                Clear();
            }
            else
            {
                MessageBox.Show("Rcord does not exist");
                Clear();
            }
            con.Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            Clear();
            loadequipment();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            status = "Add";
            con.Open();

            String sql = ("SELECT * FROM Equipment WHERE Equipment_NO = '" + txn.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Record already exist");
                Clear();

            }
            else if (txn.Text == "")
            {
                MessageBox.Show("Enter the equipment number");
            }
            else
            {
                txn.Enabled = false;
                txna.Enabled = true;
                txav.Enabled = true;
                txc.Enabled = true;
                txd.Enabled = true;
            }
            con.Close();
        }

        private void Equipment_Load(object sender, EventArgs e)
        {
            Clear();
            loadequipment();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            status = "Edit";
            con.Open();

            String sql = ("SELECT * FROM Equipment WHERE Equipment_NO='" + txn.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                txn.Text = dr["Equipment_NO"].ToString();
                txna.Text = dr["Equipment_Name"].ToString();
                txav.Text = dr["Available_Branch"].ToString();
                txc.Text = dr["Coast"].ToString();
                txd.Text = dr["Description"].ToString();

                txn.Enabled = false;
                txna.Enabled = true;
                txav.Enabled = true;
                txc.Enabled = true;
                txd.Enabled = true;

            }
            else if (txn.Text == "")
            {
                MessageBox.Show("Enter the equipment number");
                Clear();
            }
            else
            {
                MessageBox.Show("Rcord does not exist");
                Clear();
            }
            con.Close();
        }

        private void btnsav_Click(object sender, EventArgs e)
        {
            if (txn.Text == "")
            {
                MessageBox.Show("Select a action");
                txn.Text = "";
            }
            else if (txna.Text == "")
            {
                MessageBox.Show("Name can't be empty");
                txn.Text = "";
                Clear();
            }
            else if (txav.Text == "")
            {
                MessageBox.Show("Available branch can't be empty");
            }
            else if (txc.Text == "")
            {
                MessageBox.Show("Cost can't be empty");
            }
            else if (txd.Text == "")
            {
                MessageBox.Show("Description can't be empty");
            }
            else
            {
                if (status == "Add")
                {
                    con.Open();
                    String Sql = "INSERT INTO Equipment (Equipment_NO,Equipment_Name,Description,Available_Branch,Coast)VALUES('" + txn.Text + "','" + txna.Text + "','" + txd.Text + "','" + txav.Text + "','" + txc.Text + "')";
                    com = new SqlCommand(Sql, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Record successfuly saved");
                    Clear();

                    con.Close();
                    loadequipment();
                    con.Close();
                }
                else if (status == "Edit")
                {
                    con.Open();
                    String sql = "UPDATE Equipment SET Equipment_Name='" + txna.Text + "',Description='" + txd.Text + "',Available_Branch='" + txav.Text + "',Coast='" + txc.Text+ "' WHERE Equipment_NO = '" + txn.Text + "'";
                    com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Record updated sucessfully");
                    Clear();

                }
                else if (txn.Text == "")
                {
                    MessageBox.Show("Select a action");
                    Clear();
                }
                else
                {

                }
                con.Close();
                loadequipment();
                con.Close();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            status = "Delete";
            con.Open();


            String sql = ("SELECT * FROM Equipment WHERE Equipment_NO='" + txn.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                txn.Text = dr["Equipment_NO"].ToString();
                txna.Text = dr["Equipment_Name"].ToString();
                txav.Text = dr["Available_Branch"].ToString();
                txc.Text = dr["Coast"].ToString();
                txd.Text = dr["Description"].ToString();

                DialogResult msg = MessageBox.Show("Are you sure to delete?", "Confiremation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    con.Close();
                    con.Open();
                    String sqla = "DELETE  FROM Equipment WHERE Equipment_NO='" + txn.Text + "'";
                    com = new SqlCommand(sqla, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Record delete succssessfully");
                    Clear();
                }
                else { }
            }
            else if (txn.Text == "")
            {
                MessageBox.Show("Enter the Equipment number");
                Clear();
            }
            else
            {
                MessageBox.Show("Rcord does not exist");
                Clear();
            }
            con.Close();
            loadequipment();
            con.Close();
        }

        private void LV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LV.SelectedItems.Count>0)
                {
                    ListViewItem SelectRecord = LV.SelectedItems[0];
                    txn.Text = SelectRecord.SubItems[0].Text;
                    txna.Text = SelectRecord.SubItems[1].Text;
                    txav.Text = SelectRecord.SubItems[2].Text;
                    txc.Text = SelectRecord.SubItems[3].Text;
                    txd.Text = SelectRecord.SubItems[4].Text;
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void bts_Click(object sender, EventArgs e)
        {
            con.Open();

            String sql = ("SELECT * FROM Equipment WHERE Equipment_NO='" + txs.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                txn.Text = dr["Equipment_NO"].ToString();
                txna.Text = dr["Equipment_Name"].ToString();
                txav.Text = dr["Available_Branch"].ToString();
                txc.Text = dr["Coast"].ToString();
                txd.Text = dr["Description"].ToString();
                txs.Text = "";
                txn.Enabled = false;
                txna.Enabled = false;
                txav.Enabled = false;
                txc.Enabled = false;
                txd.Enabled = false;

            }
            else if (txn.Text == "")
            {
                MessageBox.Show("Enter the equipment number");
                Clear();
            }
            else
            {
                MessageBox.Show("Rcord does not exist");
                Clear();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bts_Click_1(object sender, EventArgs e)
        {
           
                con.Open();
                String sql = ("SELECT * FROM Equipment WHERE Equipment_NO='" + txs.Text + "'");
                com = new SqlCommand(sql, con);
                dr = com.ExecuteReader();


                if (dr.Read())
                {
                    txn.Text = dr["Equipment_NO"].ToString();
                    txna.Text = dr["Equipment_Name"].ToString();
                    txav.Text = dr["Available_Branch"].ToString();
                    txc.Text = dr["Coast"].ToString();
                    txd.Text = dr["Description"].ToString();
                    txs.Text = "";
                    txn.Enabled = false;
                    txna.Enabled = false;
                    txav.Enabled = false;
                    txc.Enabled = false;
                    txd.Enabled = false;

                }
                else 
                {
                    MessageBox.Show("Rcord does not exist");
                    Clear();
                }
                
                con.Close();
        }
    }
    
}
