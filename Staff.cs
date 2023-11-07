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
    public partial class Staff : Form
    {
        public Staff()
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
            txid.Text = "";
            txn.Text = "";
            txa.Text = "";
            dtpD.Text = "";
            txh.Text = "";
            cb.Text = "";
            cbp.Text = "";
            cbg.Text = "";
            dt.Text = "";
            ts.Text = "";
            txid.Enabled = true;
            txn.Enabled = false;
            txa.Enabled = false;
            dtpD.Enabled = false;
            txh.Enabled = false;
            cb.Enabled = false;
            cbp.Enabled = false;
            cbg.Enabled = false;
            dt.Enabled = false;
            ts.Enabled = false;
        }
        public void loadStaff()
        {
            con.Open();
            string sql = "SELECT * FROM Staff";
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();
            LV.Items.Clear();
            while (dr.Read())
            {
                ListViewItem Staff = new ListViewItem(dr["ID"].ToString());
                Staff.SubItems.Add(dr["Name"].ToString());
                Staff.SubItems.Add(dr["Address"].ToString());
                Staff.SubItems.Add(dr["DOB"].ToString());
                Staff.SubItems.Add(dr["Gender"].ToString());
                Staff.SubItems.Add(dr["Telephone"].ToString());
                Staff.SubItems.Add(dr["Branch"].ToString());
                 Staff.SubItems.Add(dr["Position"].ToString());
                Staff.SubItems.Add(dr["Salary"].ToString());
                Staff.SubItems.Add(dr["Date_Joined"].ToString());
                LV.Items.Add(Staff);
            }
            con.Close();
        }
            private void Staff_Load(object sender, EventArgs e)
        {
            Clear();
            loadStaff();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Menu a = new Menu();
            a.Show();
            this.Hide();
        }
        private void bts_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = ("SELECT * FROM Staff WHERE ID='" + txs.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                txid.Text = dr["ID"].ToString();
                txn.Text = dr["Name"].ToString();
                txa.Text = dr["Address"].ToString();
                dtpD.Text = dr["DOB"].ToString();
                txh.Text = dr["Telephone"].ToString();
                cbg.Text = dr["Gender"].ToString();
                cb.Text = dr["Branch"].ToString();
                cbp.Text = dr["Position"].ToString();
                ts.Text = dr["Salary"].ToString();
                dt.Text = dr["Date_Joined"].ToString();
                txid.Enabled = false;
                txn.Enabled = false;
                txa.Enabled = false;
                dtpD.Enabled = false;
                txh.Enabled = false;
                cb.Enabled = false;
                cbp.Enabled = false;
                cbg.Enabled = false;
                ts.Enabled = false;
                dt.Enabled = false;
                txs.Text = "";
            }
            else if (txs.Text == "")
            {
                MessageBox.Show("Enter the  Staff  ID");
                Clear();
            }
            else
            {
                MessageBox.Show("Rcord does not exist");
                Clear();
            }
            con.Close();
            loadStaff();
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
            loadStaff();
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            status = "Delete";
            con.Open();
            String sql = ("SELECT * FROM Staff WHERE ID='" + txid.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                txid.Text = dr["ID"].ToString();
                txn.Text = dr["Name"].ToString();
                txa.Text = dr["Address"].ToString();
                dtpD.Text = dr["DOB"].ToString();
                txh.Text = dr["Telephone"].ToString();
                cbg.Text = dr["Gender"].ToString();
                cb.Text = dr["Branch"].ToString();
                cbp.Text = dr["Position"].ToString();
                ts.Text = dr["Salary"].ToString();
                dt.Text = dr["Date_Joined"].ToString();
                DialogResult msg = MessageBox.Show("Are you sure to delete?", "Confiremation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    con.Close();
                    con.Open();
                    String sqla = "DELETE  FROM Staff WHERE ID='" + txid.Text + "'";
                    com = new SqlCommand(sqla, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Record delete succssessfully");
                    Clear();
                }
                else { }
            }
            else if (txid.Text == "")
            {
                MessageBox.Show("Enter the Staff  ID");
                Clear();
            }
            else
            {
                MessageBox.Show("Rcord does not exist");
                Clear();
            }
            con.Close();
            loadStaff();
            con.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            status = "Edit";
            con.Open();
            String sql = ("SELECT * FROM Staff WHERE ID='" + txid.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                txid.Text = dr["ID"].ToString();
                txn.Text = dr["Name"].ToString();
                txa.Text = dr["Address"].ToString();
                dtpD.Text = dr["DOB"].ToString();
                txh.Text = dr["Telephone"].ToString();
                cbg.Text = dr["Gender"].ToString();
                cb.Text = dr["Branch"].ToString();
                cbp.Text = dr["Position"].ToString();
                ts.Text = dr["Salary"].ToString();
                dt.Text = dr["Date_Joined"].ToString();
                txid.Enabled = false;
                txn.Enabled = true;
                txa.Enabled = true;
                dtpD.Enabled = true;
                txh.Enabled = true;
                cb.Enabled = true;
                cbp.Enabled = true;
                cbg.Enabled = true;
                dt.Enabled = true;
                ts.Enabled = true;
            }
            else if (txid.Text == "")
            {
                MessageBox.Show("Enter the Staff ID");
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
            status = "Add";
            con.Open();
            String sql = ("SELECT * FROM Staff WHERE ID='" + txid.Text + "'");
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Record already exist");
                Clear();
            }
            else if (txid.Text == "")
            {
                MessageBox.Show("Enter the  Staff ID");
            }
            else
            {
                txid.Enabled = false;
                txn.Enabled = true;
                txa.Enabled = true;
                dtpD.Enabled = true;
                txh.Enabled = true;
                cb.Enabled = true;
                cbp.Enabled = true;
                cbg.Enabled = true;
                dt.Enabled = true;
                ts.Enabled = true;
            }
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (txid.Text == "")
            {
                MessageBox.Show("Select a action");
                txid.Text = "";
            }
            else if (txn.Text == "")
            {
                MessageBox.Show("Name can't be empty");
            }
            else if (txa.Text == "")
            {
                MessageBox.Show("Address can't be empty");
            }
            else if (dtpD.Text == "")
            {
                MessageBox.Show("DOB can't be empty");
            }
            else if (cbg.Text == "")
            {
                MessageBox.Show("Gender can't be empty");
            }
            else if (txh.Text == "")
            {
                MessageBox.Show("Telephone can't be empty");
            }
            else if (cb.Text == "")
            {
                MessageBox.Show("Branch can't be empty");
            }
            else if (cbp.Text == "")
            {
                MessageBox.Show("Position can't be empty");
            }
            else if (ts.Text == "")
            {
                MessageBox.Show("Salary can't be empty");
            }
            else if (dt.Text == "")
            {
                MessageBox.Show("Date joined can't be empty");
            }
            else
            {
                if (status == "Add")
                {
                    con.Open();
                    String Sql = "INSERT INTO Staff (ID,Name,Address,DOB,Gender,Telephone,Branch,Position,Salary,Date_Joined)VALUES('" + txid.Text + "','" + txn.Text + "','" + txa.Text + "','" + dtpD.Text + "','" + cbg.Text + "','" + txh.Text + "','" + cb.Text + "','" + cbp.Text + "','"+ts.Text+"','" + dt.Text + "')";
                    com = new SqlCommand(Sql, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Record successfuly saved");
                    txa.Text = "";
                    txn.Text = "";
                    txh.Text = "";
                    cb.Text = "";
                    txid.Text = "";
                    dt.Text = "";
                    dtpD.Text = "";
                    cbg.Text = "";
                    ts.Text = "";
                    cbp.Text = "";
                    txid.Enabled = true;
                    cbp.Enabled = false;
                    txn.Enabled = false;
                    txa.Enabled = false;
                    txh.Enabled = false;
                    dt.Enabled = false;
                    dtpD.Enabled = false;
                    cbg.Enabled = false;
                    cb.Enabled = false;
                    ts.Enabled = false;
                    con.Close();
                    loadStaff();
                    con.Close();
                }
                else if (status == "Edit")
                {
                    con.Open();
                    String sql = "UPDATE Staff SET  Name='" + txn.Text + "',Address='" + txa.Text + "',DOB ='" + dtpD.Text + "',Gender='" + cbg.Text + "',Telephone='" + txh.Text + "',Branch='" + cb.Text + "',Position='" + cbp.Text + "',Salary='" + ts.Text+"',Date_Joined='" + dt.Text + "' WHERE ID = '" + txid.Text + "'";
                    com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Record updated sucessfully");
                    Clear();
                }
                else if (txid.Text == "")
                {
                    MessageBox.Show("Select a action");
                    Clear();
                }
                else
                {
                }
                con.Close();
                loadStaff();
                con.Close();
            }
        }
        private void LV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LV.SelectedItems.Count > 0)
                {
                    ListViewItem SelectRecord = LV.SelectedItems[0];
                    txid.Text = SelectRecord.SubItems[0].Text;
                    txn.Text = SelectRecord.SubItems[1].Text;
                    txa.Text = SelectRecord.SubItems[2].Text;
                    dtpD.Text = SelectRecord.SubItems[3].Text;
                    cbg.Text = SelectRecord.SubItems[4].Text;
                    txh.Text = SelectRecord.SubItems[5].Text;
                    cb.Text = SelectRecord.SubItems[6].Text;
                    cbp.Text = SelectRecord.SubItems[7].Text;
                    ts.Text = SelectRecord.SubItems[8].Text;
                    dt.Text = SelectRecord.SubItems[9].Text;
                }       
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
