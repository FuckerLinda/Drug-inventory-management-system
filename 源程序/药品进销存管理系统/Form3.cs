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
    public partial class drug : Form
    {
        int ifadmin;
        public drug(int if_admin)
        {
            ifadmin = if_admin;
            InitializeComponent();
        }

        private void drug_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DBConnect.con();
                String sql = "select * from drug_info";
                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                Adpt.Fill(ds, "drug_info");
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
                type.Text = dataGridView1.SelectedCells[3].Value.ToString();

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
            String sql = "select * from drug_info where drug_id='" + id+"'";
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
            if (id.Text != "" )
            {
                if (ifadmin == 1)
                {
                    if (!Check(id.Text))
                    {
                        SqlConnection con = DBConnect.con();
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "insert into drug_info values('" + id.Text + "','" + name.Text + "','" + count.Text + "','" + type.Text + "')";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        String sql = "select * from drug_info";
                        SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        Adpt.Fill(ds, "drug_info");
                        dataGridView1.DataSource = ds.Tables[0].DefaultView;
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("药品编号不能重复！");
                    }
                }
                else
                {
                    MessageBox.Show("非法用户！");
                }
            }
            else
            {
                MessageBox.Show("药品编号不能为空！");
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
                            try {
                            SqlConnection con = DBConnect.con();
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "update drug_info set name='" + name.Text + "',count='" + count.Text + "',type='" + type.Text + "' where drug_id='" + id.Text + "'";
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("修改成功！");
                            String sql = "select * from drug_info";
                            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                            DataSet ds = new DataSet();
                            Adpt.Fill(ds, "drug_info");
                            dataGridView1.DataSource = ds.Tables[0].DefaultView;
                            con.Close();
                            }
                            catch(Exception cw)
                            {
                                MessageBox.Show(cw.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("药品编号不存在！");
                        }

                    }
                    else
                    {
                        MessageBox.Show("药品编号不能为空！");
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
                    if (id.Text != "")
                    {
                        if (Check(id.Text))
                        {
                            try
                            {
                                SqlConnection con = DBConnect.con();
                                con.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "delete from drug_info where drug_id='" + id.Text +"'";
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("删除成功！");
                                String sql = "select * from drug_info";
                                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                                DataSet ds = new DataSet();
                                Adpt.Fill(ds, "drug_info");
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
                            MessageBox.Show("药品编号不存在！");
                        }

                    }
                    else
                    {
                        MessageBox.Show("药品编号不能为空！");
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
                       // cmd.CommandText = "select * from drug_info where drug_id like '%" + id.Text + "%' and name like '%" + name.Text + "%' and count like '%" + count.Text + "%' and type like '%" + type.Text+"%'" ;
                       // cmd.Connection = con;
                       // cmd.ExecuteNonQuery();
                       // String sql = "select * from drug_info";
                        String sql = "select * from drug_info where drug_id like '%" + id.Text + "%' and name like '%" + name.Text + "%' and count like '%" + count.Text + "%' and type like '%" + type.Text + "%'";
                        SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        Adpt.Fill(ds, "drug_info");
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
