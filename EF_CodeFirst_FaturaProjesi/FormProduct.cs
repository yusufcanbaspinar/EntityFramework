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
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }

        InvoiceProjectContext db = DbSingletone.GetInstance();
        int secilenProductID;
        int secilenUnitID;
        List<int> SilinecekID;

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            ComboDoldur();
            List();
        }

        public void ComboDoldur()
        {
            cmbUnit.DisplayMember = "UnitName";
            cmbUnit.ValueMember = "UnitID";
            cmbUnit.DataSource = db.Units.ToList();
        }

        public void List()
        {
            dataGridView1.DataSource = db.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.ProductNumber,
                x.Unit.UnitName,
                x.UnitPrice
            }).ToList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductName = txtProductName.Text;
            product.ProductNumber = Convert.ToInt32(txtProductNumber.Text);
            product.UnitID = (int)cmbUnit.SelectedValue;
            product.UnitPrice = Convert.ToInt32(txtUnitPrice.Text);
            db.Products.Add(product);
            db.SaveChanges();
            List();
            txtProductName.Text = string.Empty;
            txtProductNumber.Text= string.Empty;
            txtUnitPrice.Text= string.Empty;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenProductID =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            txtProductName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtProductNumber.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbUnit.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtUnitPrice.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = db.Products.Find(secilenProductID);
            product.ProductName = txtProductName.Text;
            product.ProductNumber =Convert.ToInt32(txtProductNumber.Text);
            product.UnitPrice = Convert.ToInt32(txtUnitPrice.Text);
            db.SaveChanges();
            List();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product product = db.Products.Find(secilenProductID);
            db.Products.Remove(product);
            db.SaveChanges();
            List();
            txtProductName.Text = string.Empty;
            txtProductNumber.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
        }

        private void btnMultiDelete_Click(object sender, EventArgs e)
        {
            SilinecekID = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SilinecekID.Add(Convert.ToInt32(row.Cells[0].Value));
            }


            if (dataGridView1.SelectedRows.Count > 1)
            {
                DialogResult dr = new DialogResult();
                string s = string.Format("Do you want to delete selected {0} rows", dataGridView1.SelectedRows.Count);
                dr = MessageBox.Show(s, "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (var item in SilinecekID)
                    {
                        Product product = db.Products.Find(item);
                        db.Products.Remove(product);
                        db.SaveChanges();
                        List();
                        txtProductName.Text = string.Empty;
                        txtProductNumber.Text = string.Empty;
                        txtUnitPrice.Text = string.Empty;
                    }
                }
                else
                {
                    SilinecekID = new List<int>();
                }
            }
            else
            {
                MessageBox.Show("Select row more than one");
            }
        }
    }
}
