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
    public partial class AccountMenu2 : Form
    {
        public AccountMenu2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Edit_Members2 sn = new Edit_Members2();
            sn.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete_Account2 ad = new Delete_Account2();
            ad.Show();
            this.Hide();
        }

        private void btnsystem_Click(object sender, EventArgs e)
        {
            Menu2 a = new Menu2();
            a.Show();
            this.Hide();
        }
    }
}
