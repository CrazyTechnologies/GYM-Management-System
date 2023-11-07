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
    public partial class Menu2 : Form
    {
        public Menu2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Members2 b = new Members2();
            b.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Do you want to Sign Up?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
               LOGIN a = new LOGIN();
                a.Show();
                this.Hide();
            }
            else { }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Equipment2 a = new Equipment2();
            a.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AccountMenu2 cb = new AccountMenu2();
            cb.Show();
            this.Hide();
        }

        private void Menu2_Load(object sender, EventArgs e)
        {
            lb.Text = "Username";
        }
    }
}
