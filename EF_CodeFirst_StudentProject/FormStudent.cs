using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CodeFirst_StudentProject
{
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
        }
        StudentClass ctx = new StudentClass();
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {

            cmbDoldur();
            Doldur();


        }

        public void cmbDoldur()
        {
            

            var clist = ctx.Classes.Select(x => new
            {
                x.Class_ID,
                x.Description
            }).ToList();

            cmbClass.DisplayMember = "Description";
            cmbClass.ValueMember = "Class_ID";
            cmbClass.DataSource = clist;
        }

        public void Doldur()
        {
            dataGridView1.DataSource = ctx.Students.Select(x => new
            {
                x.TCID,
                x.FullName,
                x.Class_.Description
            }).ToList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.TCID = Convert.ToInt32(txtTCKNo.Text);
            s.FullName = txtName.Text;
            s.Class_Id = (int)cmbClass.SelectedValue;
            ctx.Students.Add(s);
            ctx.SaveChanges();
            Doldur();
        }
    }
}
