using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace univesity
{
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-FI7KKQC\SQLEXPRESS;Initial Catalog=University;Integrated Security=true");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        SqlDataAdapter da2;
        DataTable dt2 = new DataTable();

        public Form2()
        {
            InitializeComponent();
            conn.Open();
            SqlCommand comm1 = new SqlCommand("select max(stud_id) from student",conn);
            SqlDataReader dr1 = comm1.ExecuteReader();
            dr1.Read();
            String id1 = dr1[0].ToString();
            int id = int.Parse(id1) + 1;
            textBox1.Text = id.ToString();
            conn.Close();

            conn.Open();
            dt.Clear();
            da = new SqlDataAdapter("select stud_id,stud_name,stud_address,stud_phone from student", conn);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "stud_id";
            textBox5.DataBindings.Add("Text", dt, "stud_name");
            textBox6.DataBindings.Add("Text", dt, "stud_address");
            textBox7.DataBindings.Add("Text", dt, "stud_phone");
            conn.Close();
            


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm1 = new SqlCommand("insert into student values('"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"') ", conn);
            comm1.ExecuteNonQuery();
            MessageBox.Show("Adding is Successfull...");
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            string id = textBox1.Text;
            int id2 = int.Parse(id) + 1;
            textBox1.Text = id2.ToString();
            conn.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn.Open();
            dt.Clear();
            da = new SqlDataAdapter("select * from student", conn);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "stud_id";
           // textBox5.DataBindings.Add("Text", dt, "stud_name");
           // textBox6.DataBindings.Add("Text", dt, "stud_address");
            //textBox7.DataBindings.Add("Text", dt, "stud_phone");
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            String id = comboBox1.Text;
            Int32 id2 = Convert.ToInt32(id);
            SqlCommand comm1 = new SqlCommand("update student SET stud_name='" + textBox5.Text + "',stud_address='" + textBox6.Text + "',stud_phone='" + textBox7.Text + "' where stud_id='"+id2+"' ", conn);
            comm1.ExecuteNonQuery();
            MessageBox.Show("Updating is Successfull...");
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            String id = comboBox1.Text;
            Int32 id2 = Convert.ToInt32(id);
            SqlCommand comm1 = new SqlCommand("Delete from student where student_id='" + id2 + "' ", conn);
            comm1.ExecuteNonQuery();
            MessageBox.Show("deleting is Successfull...");
            conn.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            dt2.Clear();
            da2 = new SqlDataAdapter("Select * from student", conn);
            da.Fill(dt2);
            dataGridView1.DataSource = dt2;
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommandBuilder cb = new SqlCommandBuilder(da2);
            da2.Update(dt2);
            MessageBox.Show("Saving is successfull...");
            conn.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
