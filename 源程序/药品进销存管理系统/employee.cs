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
    public partial class employee : Form
    {
        int ifadmin;
        int sex = 0;
        public employee(int if_admin)
        {
            ifadmin = if_admin;
            InitializeComponent();
        }

        private void employee_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DBConnect.con();
                String sql = "select * from employee";
                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                Adpt.Fill(ds, "employee");
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
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
                id.Text = dataGridView1.SelectedCells[0].Value.ToString();
                name.Text = dataGridView1.SelectedCells[1].Value.ToString();
                count.Text = dataGridView1.SelectedCells[2].Value.ToString();
                telephone.Text = dataGridView1.SelectedCells[3].Value.ToString();

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
            String sql = "select * from employee where uid='" + id + "'";
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
            if (id.Text != "")
            {
                if (ifadmin == 1)
                {
                    if (!Check(id.Text))
                    {
                        SqlConnection con = DBConnect.con();
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        if (count.Text == "女") sex = 1;
                        cmd.CommandText = "insert into employee values('" + id.Text + "','" + name.Text + "','" + sex + "','" + telephone.Text + "')";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        String sql = "select * from employee";
                        SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        Adpt.Fill(ds, "employee");
                        dataGridView1.DataSource = ds.Tables[0].DefaultView;
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("员工编号不能重复！");
                    }
                }
                else
                {
                    MessageBox.Show("非法用户！");
                }
            }
            else
            {
                MessageBox.Show("员工编号不能为空！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ifadmin == 1)
            {
                if (MessageBox.Show("确认修改？", "消息框", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (id.Text != "")
                    {
                        if (Check(id.Text))
                        {
                            try
                            {
                                SqlConnection con = DBConnect.con();
                                con.Open();
                                SqlCommand cmd = new SqlCommand();
                                if (count.Text == "女") sex = 1;

                                cmd.CommandText = "update employee set name='" + name.Text + "',sex='" + sex + "',telephone='" + telephone.Text + "' where uid='" + id.Text + "'";
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("修改成功！");
                                String sql = "select * from employee";
                                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                                DataSet ds = new DataSet();
                                Adpt.Fill(ds, "employee");
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
                            MessageBox.Show("员工编号不存在！");
                        }

                    }
                    else
                    {
                        MessageBox.Show("员工编号不能为空！");
                    }
                }
            }
    }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ifadmin == 1)
            {
                if (MessageBox.Show("确认删除？", "消息框", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (id.Text != "")
                    {
                        if (Check(id.Text))
                        {
                            try
                            {
                                SqlConnection con = DBConnect.con();
                                con.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "delete from employee where uid='" + id.Text + "'";
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("删除成功！");
                                String sql = "select * from employee";
                                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                                DataSet ds = new DataSet();
                                Adpt.Fill(ds, "employee");
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
                            MessageBox.Show("员工编号不存在！");
                        }

                    }
                    else
                    {
                        MessageBox.Show("员工编号不能为空！");
                    }
                }
            }
            else
            {
                MessageBox.Show("非法用户！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DBConnect.con();
                con.Open();
                // SqlCommand cmd = new SqlCommand();
                // cmd.CommandText = "select * from employee where uid like '%" + id.Text + "%' and name like '%" + name.Text + "%' and count like '%" + count.Text + "%' and telephone like '%" + telephone.Text+"%'" ;
                // cmd.Connection = con;
                // cmd.ExecuteNonQuery();
                // String sql = "select * from employee";
                if (count.Text == "女") sex = 1;
                else if (count.Text == "男") sex = 0;
                else sex = 3;
                String sql;
                if (sex == 0 || sex == 1)
                    sql = "select * from employee where uid like '%" + id.Text + "%' and name like '%" + name.Text + "%' and sex like '%" + sex + "%' and telephone like '%" + telephone.Text + "%'";
                else sql = "select * from employee where uid like '%" + id.Text + "%' and name like '%" + name.Text + "%' and telephone like '%" + telephone.Text + "%'";
                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                Adpt.Fill(ds, "employee");
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                con.Close();
            }
            catch (Exception cw)
            {
                MessageBox.Show(cw.Message);
            }
        }
    }
    }
