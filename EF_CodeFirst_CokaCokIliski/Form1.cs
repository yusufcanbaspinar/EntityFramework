using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CodeFirst_CokaCokIliski
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void öğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOgrenci frm = new FormOgrenci();
            frm.Show();
            this.Hide();
        }

        private void eğitmenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormEgitmen frm = new FormEgitmen();
            frm.Show();
            this.Hide();
        }

        private void öğrenciEğitmenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIliski frm = new FormIliski();
            frm.Show();
            this.Hide();
        }
    }
}
