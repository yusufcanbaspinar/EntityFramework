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
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }
        InvoiceProjectContext db = DbSingletone.GetInstance();
        int secilenCityID;
        int secilenCustomerID;
        List<int> SilinecekID;

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            ComboCityDoldur();
            List();
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        public void List()
        {
            dataGridView1.DataSource = db.Customers.Select(x => new
            {
                x.CustomerID,
                x.CompanyName,
                x.county.City.CityName,
                x.county.CountyName,
                x.Adrress
            }).ToList();



        }

        public void ComboCityDoldur()
        {
            cmbCustomerCity.DisplayMember = "CityName";
            cmbCustomerCity.ValueMember = "CityID";
            cmbCustomerCity.DataSource = db.Cities.ToList();
        }

        public void ComboCountyDoldur()
        {
            City city = db.Cities.Find(secilenCityID);
            cmbCustomerCounty.DisplayMember = "CountyName";
            cmbCustomerCounty.ValueMember = "CountyID";
            cmbCustomerCounty.DataSource = city.counties.ToList();
        }

        private void cmbCustomerCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilenCityID = (int)cmbCustomerCity.SelectedValue;
            ComboCountyDoldur();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer();
                customer.CompanyName = txtCompanyName.Text;
                customer.CountyID = (int)cmbCustomerCounty.SelectedValue;
                customer.Adrress = txtAddress.Text;
                db.Customers.Add(customer);
                db.SaveChanges();
                List();
                txtCompanyName.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = db.Customers.Find(secilenCustomerID);
                customer.CompanyName = txtCompanyName.Text;
                customer.CountyID = (int)cmbCustomerCounty.SelectedValue;
                customer.Adrress = txtAddress.Text;
                db.SaveChanges();
                List();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenCustomerID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            txtCompanyName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cmbCustomerCity.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbCustomerCounty.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtAddress.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();




        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = db.Customers.Find(secilenCustomerID);
                db.Customers.Remove(customer);
                db.SaveChanges();
                List();
                txtCompanyName.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

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
                        Customer customer = db.Customers.Find(item);
                        db.Customers.Remove(customer);
                        db.SaveChanges();
                        List();
                    }
                    txtCompanyName.Text = string.Empty;
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
