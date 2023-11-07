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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Staff a = new Staff();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Members b = new Members();
            b.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Equipment a = new Equipment();
            a.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Selection_Menu sn = new Selection_Menu();
            sn.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Do you want to Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                Form1 a = new Form1();
                a.Show();
                this.Hide();
            }
            else { }
        }
    }
}
