using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 药品进销存管理系统
{
    public partial class Form2 : Form
    {

        int ifadmin;
        public Form2(int if_admin)
        {
            ifadmin = if_admin;
            InitializeComponent();
            
        }

        private void 药品库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            firm f = new firm(ifadmin);
            f.Show();
        }

        private void 员工信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee ee = new employee(ifadmin);
            ee.Show();
        }

        private void 药品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drug d = new drug(ifadmin);
            d.Show();
        }

        private void 药品库存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            store s = new store(ifadmin);
            s.Show();
     
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Fmlogin = new Form1();
            Fmlogin.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void 药品进货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchases p = new purchases(ifadmin);
            p.Show();
        }

        private void 药品零售ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sell s = new sell(ifadmin);
            s.Show();
        }

        private void 客户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customer c = new customer(ifadmin);
            c.Show();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            users u = new users(ifadmin);
            u.Show();
        }
    }
}
