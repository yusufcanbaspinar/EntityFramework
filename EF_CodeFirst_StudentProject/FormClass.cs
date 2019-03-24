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
    public partial class FormClass : Form
    {
        public FormClass()
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //Class_ c = new Class_();
            //c.Description = txtDescription.Text;
            //ctx.Classes.Add(c);

            Class_ c = new Class_ { Description = txtDescription.Text };
            ctx.Classes.Add(c);
            ctx.SaveChanges();
            Doldur();

        }

        private void FormClass_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        public void Doldur()
        {
            dataGridView1.DataSource = ctx.Classes.Select(x => new
            {
                x.Class_ID,
                x.Description
            }).ToList();
        }
    }
}
