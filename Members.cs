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
    public partial class Members : Form
    {
        public Members()
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
            txa.Text = "";
            txf.Text = "";
            txH.Text = "";
            txl.Text = "";
            txmid.Text = "";
            dt.Text = "";
            dtpD.Text = "";
            cbg.Text = "";
            cbgt.Text = "";
            txmid.Enabled = true;
            txf.Enabled = false;
            txl.Enabled = false;
            txa.Enabled = false;
            txH.Enabled = false;
            dt.Enabled = false;
            dtpD.Enabled = false;
            cbg.Enabled = false;
            cbgt.Enabled = false;
        }

        public void loadmember()
        {
            con.Open();
            string sql = "SELECT * FROM tblMember";
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();

            LV.Items.Clear();

            while (dr.Read())
            {
                ListViewItem member = new ListViewItem(dr["Member_ID"].ToString());
                member.SubItems.Add(dr["Full_Name"].ToString());
                member.SubItems.Add(dr["Name_with_initial"].ToString());
                member.SubItems.Add(dr["Address"].ToString());
                member.SubItems.Add(dr["DOB"].ToString());
                member.SubItems.Add(dr["Gender"].ToString());
                member.SubItems.Add(dr["Telephone"].ToString());
                member.SubItems.Add(dr["Gym_Time"].ToString());
                member.SubItems.Add(dr["Joined_Date"].ToString());

                LV.Items.Add(member);
            }
            con.Close();
        }

        private void Members_Load(object sender, EventArgs e)
        {
            txmid.Enabled = true;
            txf.Enabled = false;
            txH.Enabled = false;
            txl.Enabled = false;
            txa.Enabled = false;
            dt.Enabled = false;
            dtpD.Enabled = false;
            cbg.Enabled = false;
            cbgt.Enabled = false;

            loadmember();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void bts_Click(object sender, EventArgs e)
        {
            status = "Search";
            con.Open();
           
            String sql = ("SELECT * FROM tblMember WHERE Member_ID='" + txs.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                txmid.Text = dr["Member_ID"].ToString();
                txf.Text = dr["Full_Name"].ToString();
                txl.Text = dr["Name_with_initial"].ToString();
                dtpD.Text = dr["DOB"].ToString();
                txH.Text = dr["Telephone"].ToString();
                cbg.Text = dr["Gender"].ToString();
                txa.Text = dr["Address"].ToString();
                cbgt.Text = dr["Gym_Time"].ToString();
                dt.Text = dr["Joined_Date"].ToString();

                txs.Text = "";
            }
            else if (txs.Text == "")
            {
                MessageBox.Show("Enter the membership ID");
                Clear();
            }
            else
            {
                MessageBox.Show("Rcord does not exist");
                Clear();
            }
            con.Close();
            loadmember();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu b = new Menu();
            b.Show();
            this.Hide();
        }

        private void btndelete_Click_1(object sender, EventArgs e)

        {
            status = "Delete";
            con.Open();


            String sql = ("SELECT * FROM tblMember WHERE Member_ID='" + txmid.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                txmid.Text = dr["Member_ID"].ToString();
                txf.Text = dr["Full_Name"].ToString();
                txl.Text = dr["Name_with_initial"].ToString();
                dtpD.Text = dr["DOB"].ToString();
                txH.Text = dr["Telephone"].ToString();
                cbg.Text = dr["Gender"].ToString();
                txa.Text = dr["Address"].ToString();
                cbgt.Text = dr["Gym_Time"].ToString();
                dt.Text = dr["Joined_Date"].ToString();


                DialogResult msg = MessageBox.Show("Are you sure to delete?", "Confiremation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    con.Close();
                    con.Open();
                    String sqla = "DELETE  FROM tblMember WHERE Member_ID='" + txmid.Text + "'";
                    com = new SqlCommand(sqla, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Record delete succssessfully");
                    Clear();
                }
                else { }
            }
            else if (txmid.Text == "")
            {
                MessageBox.Show("Enter the membership ID");
                Clear();
            }
            else
            {
                MessageBox.Show("Rcord does not exist");
                Clear();
            }
            con.Close();
            loadmember();
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            status = "Add";
            con.Open();

            String sql = ("SELECT * FROM tblMember WHERE Member_ID='" + txmid.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Record already exist");
                Clear();
            }
            else if (txmid.Text == "")
            {
                MessageBox.Show("Enter the membership ID");
            }
            else
            {
                txmid.Enabled = false;
                txf.Enabled = true;
                txH.Enabled = true;
                txl.Enabled = true;
                txa.Enabled = true;
                dt.Enabled = true;
                dtpD.Enabled = true;
                cbg.Enabled = true;
                cbgt.Enabled = true;


            }
            con.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            status = "Edit";
            con.Open();

            String sql = ("SELECT * FROM tblMember WHERE Member_ID='" + txmid.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                txmid.Text = dr["Member_ID"].ToString();
                txf.Text = dr["Full_Name"].ToString();
                txl.Text = dr["Name_with_initial"].ToString();
                dtpD.Text = dr["DOB"].ToString();
                txH.Text = dr["Telephone"].ToString();
                cbg.Text = dr["Gender"].ToString();
                txa.Text = dr["Address"].ToString();
                cbgt.Text = dr["Gym_Time"].ToString();
                dt.Text = dr["Joined_Date"].ToString();


                txmid.Enabled = false;
                txf.Enabled = true;
                txl.Enabled = true;
                txa.Enabled = true;
                dtpD.Enabled = true;
                dt.Enabled = true;
                cbg.Enabled = true;
                cbgt.Enabled = true;
                txH.Enabled = true;

            }
            else if (txmid.Text == "")
            {
                MessageBox.Show("Enter the membership ID");
                Clear();
            }
            else
            {
                MessageBox.Show("Rcord does not exist");
                Clear();
            }
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (txmid.Text == "")
            {
                MessageBox.Show("Select a action");
                txmid.Text = "";
            }
            else if (txf.Text == "")
            {
                MessageBox.Show("Full Name can't be empty");
                txmid.Text = "";
                Clear();
            }
            else if (txl.Text == "")
            {
                MessageBox.Show("Name can't be empty");
            }
            else if (txH.Text == "")
            {
                MessageBox.Show("Telephone can't be empty");
            }
            else if (txa.Text == "")
            {
                MessageBox.Show("Address can't be empty");
            }
            else if (cbg.Text == "")
            {
                MessageBox.Show("Gender can't be empty");
            }
            else if (cbgt.Text == "")
            {
                MessageBox.Show("Gym Time can't be empty");
            }
            else if (dt.Text == "")
            {
                MessageBox.Show("Date joined can't be empty");
            }
            else if (dtpD.Text == "")
            {
                MessageBox.Show("DOB can't be empty");
            }
            else
            {
                if (status == "Add")
                {
                    con.Open();
                    String Sql = "INSERT INTO tblMember (Member_ID,Full_Name,Name_with_initial,Address,DOB,Gender,Telephone,Gym_Time,Joined_Date)VALUES('" + txmid.Text + "','" + txf.Text + "','" + txl.Text + "','" + txa.Text + "','" + dtpD.Text + "','" + cbg.Text + "','" + txH.Text + "','" + cbgt.Text + "','" + dt.Text + "')";
                    com = new SqlCommand(Sql, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Record successfuly saved");
                    txa.Text = "";
                    txf.Text = "";
                    txH.Text = "";
                    txl.Text = "";
                    txmid.Text = "";
                    dt.Text = "";
                    dtpD.Text = "";
                    cbg.Text = "";
                    cbgt.Text = "";
                    txmid.Enabled = true;
                    txf.Enabled = false;
                    txl.Enabled = false;
                    txa.Enabled = false;
                    txH.Enabled = false;
                    dt.Enabled = false;
                    dtpD.Enabled = false;
                    cbg.Enabled = false;
                    cbgt.Enabled = false;
                    con.Close();
                    loadmember();
                    con.Close();
                }
                else if (status == "Edit")
                {
                    con.Open();
                    String sql = "UPDATE tblMember SET  Full_Name='" + txf.Text + "',Name_with_initial='" + txl.Text + "',Address='" + txa.Text + "',DOB='" + dtpD.Text + "',Gender='" + cbg.Text + "',Telephone='" + txH.Text + "',Gym_Time='" + cbgt.Text + "',Joined_Date='" + dt.Text + "' WHERE Member_ID = '" + txmid.Text + "'";
                    com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Record updated sucessfully");
                    Clear();

                }
                else if (txmid.Text == "")
                {
                    MessageBox.Show("Select a action");
                    Clear();
                }
                else
                {

                }
                con.Close();
                loadmember();
                con.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Menu c = new Menu();
            c.Show();
            this.Hide();
        }

        private void bts_Click_1(object sender, EventArgs e)
        {
            status = "Search";
            con.Open();

            String sql = ("SELECT * FROM tblMember WHERE Member_ID='" + txs.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();


            if (dr.Read())
            {
                txs.Text = "";
                txmid.Text = dr["Member_ID"].ToString();
                txf.Text = dr["Full_Name"].ToString();
                txl.Text = dr["Name_with_initial"].ToString();
                dtpD.Text = dr["DOB"].ToString();
                txH.Text = dr["Telephone"].ToString();
                cbg.Text = dr["Gender"].ToString();
                txa.Text = dr["Address"].ToString();
                cbgt.Text = dr["Gym_Time"].ToString();
                dt.Text = dr["Joined_Date"].ToString();


                txmid.Enabled = false;
                txf.Enabled = false;
                txl.Enabled = false;
                txa.Enabled = false;
                dtpD.Enabled = false;
                dt.Enabled = false;
                cbg.Enabled = false;
                cbgt.Enabled = false;
                txH.Enabled = false;

            }
            else if (txs.Text == "")
            {
                MessageBox.Show("Enter the membership ID");
                Clear();
            }
            else
            {
                MessageBox.Show("Rcord does not exist");
                Clear();
            }
            con.Close();
        }

        private void LV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (LV.SelectedItems.Count > 0)
                {
                   ListViewItem SelectedRecord = LV.SelectedItems[0];
                   txmid.Text = SelectedRecord.SubItems[0].Text;
                   txf.Text = SelectedRecord.SubItems[1].Text;
                   txl.Text = SelectedRecord.SubItems[2].Text;
                    txa.Text = SelectedRecord.SubItems[3].Text;
                    dtpD.Text = SelectedRecord.SubItems[4].Text;
                   cbg.Text = SelectedRecord.SubItems[5].Text;
                   txH.Text = SelectedRecord.SubItems[6].Text;
                   cbgt.Text = SelectedRecord.SubItems[7].Text;
                   dt.Text = SelectedRecord.SubItems[8].Text;
                }
              
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}

