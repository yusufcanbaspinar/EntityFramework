using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CodeFirst_FaturaProjesi
{
    public partial class FormInvoiceDetail : Form
    {
        public FormInvoiceDetail()
        {
            InitializeComponent();
        }

        InvoiceProjectContext db = DbSingletone.GetInstance();
        int secilenProductID, secilenCityID, secilenCountyID, secilenCustomerID, selectedProductID;
        bool a = true;
        List<InvoiceDetail> list = new List<InvoiceDetail>();

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void FormInvoiceHeader_Load(object sender, EventArgs e)
        {
            ComboProduct();
            TxtFill();
            ComboCity();

        }

        public void ComboProduct()
        {
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
            cmbProduct.DataSource = db.Products.OrderBy(x => x.ProductName).ToList();
        }

        public void TxtFill()
        {
            secilenProductID = (int)cmbProduct.SelectedValue;
            Product product = db.Products.Find(secilenProductID);
            txtUnit.Text = product.Unit.UnitName;
            txtUnitPrice.Text = product.UnitPrice.ToString();
        }
        public void ComboCity()
        {
            cmbCustomerCity.DisplayMember = "CityName";
            cmbCustomerCity.ValueMember = "CityID";
            cmbCustomerCity.DataSource = db.Cities.OrderBy(x => x.CityName).ToList();
        }

        public void ComboCounty()
        {
            City city = db.Cities.Find(secilenCityID);
            cmbCustomerCounty.DisplayMember = "CountyName";
            cmbCustomerCounty.ValueMember = "CountyID";
            cmbCustomerCounty.DataSource = city.counties.ToList();
        }
        public void ComboCustomer()
        {
            cmbCompanyName.DisplayMember = "CompanyName";
            cmbCompanyName.ValueMember = "CustomerID";
            cmbCompanyName.DataSource = db.Customers.Where(x => x.county.CityID == secilenCityID).ToList();
        }



        private void btnInsert_Click(object sender, EventArgs e)
        {
            int totalAmount = 0;
            int Quantity = (int)nudQuantity.Value;
            int UnitPrice = Convert.ToInt32(txtUnitPrice.Text);

            InvoiceDetail invoiceDetail = new InvoiceDetail();
            invoiceDetail.ProductID = (int)cmbProduct.SelectedValue;
            invoiceDetail.Quantity = Quantity;
            invoiceDetail.UnitPrice = UnitPrice;
            invoiceDetail.TotalAmount = Quantity * UnitPrice;
            invoiceDetail.VATAmount = Convert.ToInt32(txtWAT.Text);
            invoiceDetail.TotalAmountWithVAT = (int)(UnitPrice + UnitPrice * 0.18) * Quantity;
            invoiceDetail.Description = string.Empty;
            list.Add(invoiceDetail);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;


            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[9].Visible = false;



            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                totalAmount += Convert.ToInt32(row.Cells[8].Value);
            }
            txtTotalAmount.Text = totalAmount.ToString();
        }

        public void CreateInvioceDetail()
        {

            foreach (InvoiceDetail item in list)
            {
                item.InvoiceID = Convert.ToInt32(txtInvoiceID.Text);
                db.InvoiceDetails.Add(item);

            }
            db.SaveChanges();
        }

        public void CreateInvoiceHeader()
        {
            InvoiceHeader invoiceHeader = new InvoiceHeader();
            invoiceHeader.InvoiceDateTime = dtpOrderTime.Value;
            invoiceHeader.DeliveryNoteNumber = Convert.ToInt32(txtDeliveryNote.Text);
            invoiceHeader.PaymentDateTime = dtpPaymentDate.Value;
            invoiceHeader.CustomerID = (int)cmbCompanyName.SelectedValue;
            db.InvoiceHeaders.Add(invoiceHeader);
            db.SaveChanges();
            txtInvoiceID.Text = invoiceHeader.InvoiceID.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            list.RemoveAt(dataGridView1.CurrentRow.Index);
            btnInsert_Click(sender, e);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int totalAmount = 0;

            list.RemoveAt(dataGridView1.CurrentRow.Index);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[9].Visible = false;



            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                totalAmount += Convert.ToInt32(row.Cells[8].Value);
            }
            txtTotalAmount.Text = totalAmount.ToString();
        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            if (list.Count > 0)
            {
                DbContextTransaction tran = db.Database.BeginTransaction();
                try
                {

                    CreateInvoiceHeader();
                    CreateInvioceDetail();
                    tran.Commit();
                    MessageBox.Show("Invoice is created.");

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("There is an erorr");
                }
            }
            else
                MessageBox.Show("There isn't a product");

        }

        private void btnListClear_Click(object sender, EventArgs e)
        {
            list.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[9].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void cmbCustomerCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = true;
            if (a == true)
            {
                secilenCityID = (int)cmbCustomerCity.SelectedValue;
                City city = db.Cities.Find(secilenCityID);
                ComboCounty();
            }

        }

        private void cmbCustomerCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (a == true)
            {
                secilenCountyID = (int)cmbCustomerCounty.SelectedValue;
                ComboCustomer();
                a = false;
            }
        }

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = true;
            if (a == true)
            {
                secilenCustomerID = (int)cmbCompanyName.SelectedValue;
                Customer customer = db.Customers.Find(secilenCustomerID);
                a = false;
                cmbCustomerCounty.Text = customer.county.CountyName;
                //cmbCustomerCity.Text = customer.county.City.CityName;
            }
        }



        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFill();
           
        }
    }
}
