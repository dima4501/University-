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
    public partial class Form6 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-FI7KKQC\SQLEXPRESS;Initial Catalog=University;Integrated Security=true");
        SqlDataAdapter da1;
        SqlDataAdapter da2;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            conn.Open();
            dt.Clear();
            da1 = new SqlDataAdapter("select stud_id,stud_name from student", conn);
            da1.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "stud_id";
            textBox2.DataBindings.Add("Text",dt, "stud_name");
            da2 = new SqlDataAdapter("select sub_id,sub_name from subject", conn);
            da2.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "sub_id";
            textBox3.DataBindings.Add("Text", dt2, "sub_name");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           int mark =int.Parse(textBox1.Text);
            Int32 studid = Convert.ToInt32(comboBox1.Text);
            Int32 subid = Convert.ToInt32(comboBox2.Text);
            conn.Open();
            SqlCommand comm1 = new SqlCommand("insert into marks values('" + studid + "','" + subid + "','" + mark + "') ", conn);
            comm1.ExecuteNonQuery();
            MessageBox.Show("Adding is Successfull...");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            int mark = int.Parse(textBox1.Text);
            Int32 studid = Convert.ToInt32(comboBox1.Text);
            Int32 subid = Convert.ToInt32(comboBox2.Text);
            SqlCommand comm1 = new SqlCommand("update marks SET mark='" + mark + "' where stud_id='" + studid + "'and subject_id='"+subid+"' ", conn);
            comm1.ExecuteNonQuery();
            MessageBox.Show("Updating is Successfull...");
            conn.Close();
        }
    }
}
