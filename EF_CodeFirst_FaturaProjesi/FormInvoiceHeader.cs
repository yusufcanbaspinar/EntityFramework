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
    public partial class FormInvoiceHeader : Form
    {
        public FormInvoiceHeader()
        {
            InitializeComponent();
        }
        InvoiceProjectContext db = DbSingletone.GetInstance();
        bool sart;
        int secilenCityID, secilenCountyID;


        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void FormInvoiceHeader_Load(object sender, EventArgs e)
        {
            ComboCityFill();
            ListAllInvoice();
        }

        private void ListAllInvoice()
        {
            var list = db.InvoiceHeaders.Select(x => new
            {
                x.InvoiceID,
                x.CustomerID,
                x.Customer.CompanyName,
                x.Customer.county.City.CityName,
                x.Customer.county.CountyName,
                x.InvoiceDateTime,
                x.PaymentDateTime,
                x.DeliveryNoteNumber

            }).ToList();
            dataGridView1.DataSource = list;
        }

        public void ComboCityFill()
        {
            cmbCustomerCity.DisplayMember = "CityName";
            cmbCustomerCity.ValueMember = "CityID";
            cmbCustomerCity.DataSource = db.Cities.ToList();
        }

        private void ComboCountyFill()
        {
            cmbCustomerCounty.DisplayMember = "CountyName";
            cmbCustomerCounty.ValueMember = "CountyID";
            cmbCustomerCounty.DataSource = db.Counties.Where(x => x.CityID == secilenCityID).ToList();
        }

        private void ComboCustomerFill()
        {
            cmbCustomerName.DisplayMember = "CompanyName";
            cmbCustomerName.ValueMember = "CustomerID";
            cmbCustomerName.DataSource = db.Customers.Where(x => x.CountyID == secilenCountyID).ToList();
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (txtCustomerID.Text.Length > 0)
            {
                int InvoiceID;
                if (int.TryParse(txtCustomerID.Text, out InvoiceID))
                {
                    var list = db.InvoiceHeaders.Where(x => x.InvoiceID == InvoiceID).Select(x => new
                    {
                        x.InvoiceID,
                        x.CustomerID,
                        x.Customer.CompanyName,
                        x.Customer.county.City.CityName,
                        x.Customer.county.CountyName,
                        x.InvoiceDateTime,
                        x.PaymentDateTime,
                        x.DeliveryNoteNumber

                    }).ToList();
                    dataGridView1.DataSource = list;
                }
            }
            else
                ListAllInvoice();

        }

        private void btnListAllInvoices_Click(object sender, EventArgs e)
        {
            ListAllInvoice();
        }

        private void cmbCustomerCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilenCityID = (int)cmbCustomerCity.SelectedValue;
            var list = db.InvoiceHeaders.Where(x => x.Customer.county.CityID == secilenCityID).Select(x => new
            {
                x.InvoiceID,
                x.CustomerID,
                x.Customer.CompanyName,
                x.Customer.county.City.CityName,
                x.Customer.county.CountyName,
                x.InvoiceDateTime,
                x.PaymentDateTime,
                x.DeliveryNoteNumber

            }).ToList();
            dataGridView1.DataSource = list;
            ComboCountyFill();
        }

        private void cmbCustomerCounty_SelectedIndexChanged(object sender, EventArgs e)
        {

             secilenCountyID = (int)cmbCustomerCounty.SelectedValue;
            var list = db.InvoiceHeaders.Where(x => x.Customer.CountyID == secilenCountyID).Select(x => new
            {
                x.InvoiceID,
                x.CustomerID,
                x.Customer.CompanyName,
                x.Customer.county.City.CityName,
                x.Customer.county.CountyName,
                x.InvoiceDateTime,
                x.PaymentDateTime,
                x.DeliveryNoteNumber

            }).ToList();
            dataGridView1.DataSource = list;
            ComboCustomerFill();
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

            int secilenCustomerID = (int)cmbCustomerName.SelectedValue;
            var list = db.InvoiceHeaders.Where(x => x.CustomerID == secilenCustomerID).Select(x => new
            {
                x.InvoiceID,
                x.CustomerID,
                x.Customer.CompanyName,
                x.Customer.county.City.CityName,
                x.Customer.county.CountyName,
                x.InvoiceDateTime,
                x.PaymentDateTime,
                x.DeliveryNoteNumber

            }).ToList();
            dataGridView1.DataSource = list;

        }
    }
}

