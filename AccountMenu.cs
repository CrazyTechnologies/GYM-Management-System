using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Star_Gym
{
    public partial class Selection_Menu : Form
    {
        public Selection_Menu()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Menu s = new Menu();
            s.Show();
            this.Hide();

        }

        private void btncreateAccount_Click(object sender, EventArgs e)
        {
            Register n = new Register();
            n.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Account_edit a = new Account_edit();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete_Account sn = new Delete_Account();
            sn.Show();
            this.Hide();
        }
    }
}
