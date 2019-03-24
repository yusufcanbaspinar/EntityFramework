using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_DatabaseFirst
{
    public partial class FormGiris : Form
    {
        NorthwindEntitiesConnectionString db = DbSingleTone.GetInstance();

        public Customer secilenCustomer;
        public FormGiris()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void FormGiris_Load(object sender, EventArgs e)
        {
            Doldur();

        }

        private void Doldur()
        {
            var clist = db.Customers.ToList();
            cmbCustomer.DisplayMember = "CompanyName";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.DataSource = clist;

            var elist = db.Employees.Select(x => new
            {
                x.EmployeeID,
                FullName = x.FirstName + " " + x.LastName
            }).ToList();
            cmbEmployee.DataSource = elist;
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "EmployeeID";

            var slist = db.Shippers.Select(x => new
            {
                x.ShipperID,
                x.CompanyName
            }).ToList();
            cmbShipVia.DataSource = slist;
            cmbShipVia.DisplayMember = "CompanyName";
            cmbShipVia.ValueMember = "ShipperID";



            if (cmbCustomer.SelectedIndex != -1)
            {
                secilenCustomer = db.Customers.Find(cmbCustomer.SelectedValue);
                txtAddress.Text = secilenCustomer.Address;
                txtCountry.Text = secilenCustomer.Country;
            };

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                try
                {
                    Customer secilenCustomer = db.Customers.Find(cmbCustomer.SelectedValue);
                    txtAddress.Text = secilenCustomer.Address.ToString();
                    txtCountry.Text = secilenCustomer.Country.ToString();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

           

        }

        private void cmbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //secilenCustomer = db.Customers.Find(cmbCustomer.SelectedValue);
            //txtAddress.Text = secilenCustomer.Address;
            //txtCountry.Text = secilenCustomer.Country;
        }

        private void cmbCustomer_DisplayMemberChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Order o = new Order();
                o.CustomerID = cmbCustomer.SelectedValue.ToString();
                o.EmployeeID = (int)cmbEmployee.SelectedValue;
                o.OrderDate = dateOrder.Value;
                o.RequiredDate = dateRequired.Value;
                o.ShipVia = (int)cmbShipVia.SelectedValue;
                o.Freight = Convert.ToDecimal(txtFreight.Text);

                if (txtFreight.Text != null && dateOrder.Value > DateTime.Today && dateRequired.Value > dateOrder.Value)
                {
                    db.Orders.Add(o);
                    db.SaveChanges();

                    FormOrderHeaderDetail frm = new FormOrderHeaderDetail(o.OrderID);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Girilen verilerde hata var");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
