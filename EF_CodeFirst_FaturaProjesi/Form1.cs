using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CodeFirst_FaturaProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void cityDefinitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCity frm = new FormCity();
            frm.Show();
            this.Hide();
        }

        private void countyDefinitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCounty frm = new FormCounty();
            frm.Show();
            this.Hide();
        }
        private void customerDefinitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCustomer frm = new FormCustomer();
            frm.Show();
            this.Hide();
        }

        private void unitDefinitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUnit frm = new FormUnit();
            frm.Show();
            this.Hide();
        }

        private void urunDefinitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduct frm = new FormProduct();
            frm.Show();
            this.Hide();
        }

        private void createInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInvoiceDetail frm = new FormInvoiceDetail();
            frm.Show();
            this.Hide();
            
        }

        private void viewEditSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInvoiceHeader frm = new FormInvoiceHeader();
            frm.Show();
            this.Hide();
        }
    }
}
