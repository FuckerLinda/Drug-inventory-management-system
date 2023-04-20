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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //将输入框置空
            TxtUser.Text = "";
            TxtPass.Text = "";
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string str = "server=03BA;uid=sa;pwd=root;database=drug;";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT id,pwd from users where id=@id and pwd=@pwd and if_admin=@admin";//查找
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@admin", SqlDbType.Bit);
            cmd.Parameters[0].Value = (TxtUser.Text).Trim();
            cmd.Parameters[1].Value = (TxtPass.Text).Trim();
            cmd.Parameters[2].Value = 1;
            cmd.Connection = con;


            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();


            //若是管理员
            if (rd.Read())
            {
                Form2 mForm = new Form2(1);
                    mForm.Show();
                    con.Close();
                    this.Visible = false;
               // }
            }
            else
            {
                rd.Close();
                cmd.Parameters[2].Value = 0;
                rd = cmd.ExecuteReader();
                //若是普通用户
                if (rd.Read())
                {
                    Form2 mForm = new Form2(0);
                    mForm.Show();
                    con.Close();
                    this.Visible = false;
                }
                //若账号/密码错误
                else
                {
                    MessageBox.Show("账号密码错误，请重新输入。");
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
