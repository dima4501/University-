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
    public partial class Form7 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-TEL70DS\SQLEXPRESS;Initial Catalog=university;Integrated Security=true");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            dt.Clear();
            da = new SqlDataAdapter("select student.student_id,student.student_name,exam.exam_name,stud_exam.mark from student, exam, stud_exam where student.student_id = stud_exam.stud_id and exam.exam_id = stud_exam.exam_id", conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            conn.Open();
            dt.Clear();
            da = new SqlDataAdapter("select student.student_id,student.student_name,exam.exam_name,stud_exam.mark from student, exam, stud_exam where student.student_id = stud_exam.stud_id and exam.exam_id = stud_exam.exam_id", conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
