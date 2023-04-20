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
    public partial class purchases : Form
    {
        int ifadmin;
        public purchases(int if_admin)
        {
            ifadmin = if_admin;
            InitializeComponent();
        }

        private void purchases_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DBConnect.con();
                String sql = "select * from purchases";
                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                Adpt.Fill(ds, "purchases");
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCID";
                Adpt.SelectCommand = cmd;
                Adpt.Fill(ds, "CID");
                int i, n = ds.Tables["CID"].Rows.Count;
                for (i = 0; i < n - 1; i++) comboBox1.Items.Add(ds.Tables["CID"].Rows[i]["drug_id"]);
                cmd.CommandText = "GetGID";
                Adpt.SelectCommand = cmd;
                Adpt.Fill(ds, "GID");
                n = ds.Tables["GID"].Rows.Count;
                for (i = 0; i < n - 1; i++) comboBox2.Items.Add(ds.Tables["GID"].Rows[i]["no"]);
                cmd.CommandText = "GetHID";
                Adpt.SelectCommand = cmd;
                Adpt.Fill(ds, "HID");
                n = ds.Tables["HID"].Rows.Count;
                for (i = 0; i < n - 1; i++) comboBox3.Items.Add(ds.Tables["HID"].Rows[i]["store_id"]);

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
                //name.Text = dataGridView1.SelectedCells[1].Value.ToString();
                count.Text = dataGridView1.SelectedCells[2].Value.ToString();
                type.Text = dataGridView1.SelectedCells[3].Value.ToString();
                //textBox1.Text = dataGridView1.SelectedCells[4].Value.ToString();
                //textBox2.Text = dataGridView1.SelectedCells[5].Value.ToString();

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
            String sql = "select * from purchases where id='" + id + "'";
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




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id.Text != null)
            {
                if (ifadmin == 1)
                {
                    if (!Check(id.Text))
                    {
                        try
                        {
                            SqlConnection con = DBConnect.con();
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "insert into purchases values('" + id.Text + "','" + comboBox1.Text + "','" + count.Text + "','" + type.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox3.Text + "')";
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            String sql = "select * from purchases";
                            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                            DataSet ds = new DataSet();
                            Adpt.Fill(ds, "purchases");
                            dataGridView1.DataSource = ds.Tables[0].DefaultView;
                            con.Close();
                        }catch(Exception cw)
                        {
                            MessageBox.Show(cw.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("进货号不能重复！");
                    }
                }
                else
                {
                    MessageBox.Show("非法用户！");
                }
            }
            else
            {
                MessageBox.Show("进货号不能为空！");
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
                                cmd.CommandText = "update purchases set drug_id='" + comboBox1.Text + "',count='" + count.Text + "',price='" + type.Text + "',firm_id='" + comboBox2.Text + "',store_id='" + comboBox3.Text + "',time='" + textBox3.Text + "' where id='" + id.Text + "'";
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("修改成功！");
                                String sql = "select * from purchases";
                                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                                DataSet ds = new DataSet();
                                Adpt.Fill(ds, "purchases");
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
                            MessageBox.Show("进货号不存在！");
                        }

                    }
                    else
                    {
                        MessageBox.Show("进货号不能为空！");
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
                                cmd.CommandText = "delete from purchases where id='" + id.Text + "'";
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("删除成功！");
                                String sql = "select * from purchases";
                                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                                DataSet ds = new DataSet();
                                Adpt.Fill(ds, "purchases");
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
                            MessageBox.Show("进货号不存在！");
                        }

                    }
                    else
                    {
                        MessageBox.Show("进货号不能为空！");
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
                // cmd.CommandText = "select * from purchases where drug_id like '%" + id.Text + "%' and name like '%" + name.Text + "%' and count like '%" + count.Text + "%' and type like '%" + type.Text+"%'" ;
                // cmd.Connection = con;
                // cmd.ExecuteNonQuery();
                // String sql = "select * from purchases";
                String sql = "select * from purchases where id like '%" + id.Text + "%' and drug_id like '%" + comboBox1.Text + "%' and count like '%" + count.Text + "%' and price like '%" + type.Text + "%' and firm_id like '%" + comboBox2.Text + "%' and store_id like '%" + comboBox3.Text + "%' and time like '%" + textBox3.Text + "%'";
                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                Adpt.Fill(ds, "purchases");
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                con.Close();
            }
            catch (Exception cw)
            {
                MessageBox.Show(cw.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void type_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void count_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
