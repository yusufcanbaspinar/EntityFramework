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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void definedClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClass frm = new FormClass();
            frm.Show();
            this.Hide();
        }

        private void definedStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStudent frm = new FormStudent();
            frm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //StudentClass ctx = new StudentClass();
            //ctx.Database.CreateIfNotExists();
        }
    }
}
