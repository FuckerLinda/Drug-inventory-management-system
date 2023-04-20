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
    public partial class users : Form
    {
        int ifadmin;
        public users(int if_admin)
        {
            ifadmin = if_admin;
            InitializeComponent();
        }

        private void users_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DBConnect.con();
                String sql;
                if (ifadmin==1)
                sql = "select * from users";
                else
                    sql = "select id from users";
                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                Adpt.Fill(ds, "users");
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetUID";
                Adpt.SelectCommand = cmd;
                Adpt.Fill(ds, "UID");
                int i, n = ds.Tables["UID"].Rows.Count;
                for (i = 0; i < n - 1; i++) comboBox1.Items.Add(ds.Tables["UID"].Rows[i]["id"]);


                con.Close();
            }
            catch (Exception cw)
            {
                MessageBox.Show(cw.Message);
            }
        }


        public void blinding()
        {
            try
            {
                //id.Text = dataGridView1.SelectedCells[0].Value.ToString();
                //name.Text = dataGridView1.SelectedCells[1].Value.ToString();
                count.Text = dataGridView1.SelectedCells[2].Value.ToString();
                //type.Text = dataGridView1.SelectedCells[3].Value.ToString();
                //textBox1.Text = dataGridView1.SelectedCells[4].Value.ToString();
                //textBox2.Text = dataGridView1.SelectedCells[5].Value.ToString();
                string vip= dataGridView1.SelectedCells[3].Value.ToString();
                if (vip == "True") checkBox1.Checked = true;
                else checkBox1.Checked = false;
            }
            catch (Exception cw)
            {
                MessageBox.Show(cw.Message);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, EventArgs e)
        {
            blinding();
        }

        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {
            blinding();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private Boolean Check(String id)
        {
            SqlConnection con = DBConnect.con();
            con.Open();
            String sql = "select * from users where id='" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            int x = 0;
            while (rd.Read()) x++;
            con.Close();
            if (x > 0)
            {
                return true;
            }
            else return false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != null)
            {
                if (ifadmin == 1)
                {
                    if (!Check(comboBox1.Text))
                    {
                        try
                        {
                            SqlConnection con = DBConnect.con();
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "insert into users values('" + comboBox1.Text + "','" + count.Text+ "','" + checkBox1.Checked + "')";
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            String sql = "select * from users";
                            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                            DataSet ds = new DataSet();
                            Adpt.Fill(ds, "users");
                            dataGridView1.DataSource = ds.Tables[0].DefaultView;
                            con.Close();
                        }
                        catch (Exception cw)
                        {
                            MessageBox.Show(cw.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户名不能重复！");
                    }
                }
                else
                {
                    MessageBox.Show("非法用户！");
                }
            }
            else
            {
                MessageBox.Show("用户名不能为空！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ifadmin == 1)
            {
                if (MessageBox.Show("确认修改？", "消息框", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (comboBox1.Text != "")
                    {
                        if (Check(comboBox1.Text))
                        {
                            try
                            {
                                SqlConnection con = DBConnect.con();
                                con.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "update users set pwd='"+ count.Text+ ",if_admin=" + checkBox1.Checked+ "' where id='" + comboBox1.Text + "'";
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("修改成功！");
                                String sql = "select * from users";
                                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                                DataSet ds = new DataSet();
                                Adpt.Fill(ds, "users");
                                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                                con.Close();
                            }
                            catch (Exception cw)
                            {
                                MessageBox.Show(cw.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("用户名不存在！");
                        }

                    }
                    else
                    {
                        MessageBox.Show("用户名不能为空！");
                    }
                }
            }
            else
            {
                MessageBox.Show("非法用户！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ifadmin == 1)
            {
                if (MessageBox.Show("确认删除？", "消息框", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (comboBox1.Text != "")
                    {
                        if (Check(comboBox1.Text))
                        {
                            try
                            {
                                SqlConnection con = DBConnect.con();
                                con.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "delete from users where id='" + comboBox1.Text + "'";
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("删除成功！");
                                String sql = "select * from users";
                                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                                DataSet ds = new DataSet();
                                Adpt.Fill(ds, "users");
                                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                                con.Close();
                            }
                            catch (Exception cw)
                            {
                                MessageBox.Show(cw.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("用户名不存在！");
                        }

                    }
                    else
                    {
                        MessageBox.Show("用户名不能为空！");
                    }
                }
            }
            else
            {
                MessageBox.Show("非法用户！");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
