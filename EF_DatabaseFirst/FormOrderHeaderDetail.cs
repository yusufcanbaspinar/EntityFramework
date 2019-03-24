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
    public partial class FormOrderHeaderDetail : Form
    {
        private int gelenOrderID;
        private Order gelenOrder;
        private int secilenProductID;
        private Order_Detail secilenOrderDet;

        NorthwindEntitiesConnectionString db = DbSingleTone.GetInstance();
        public FormOrderHeaderDetail(int secilenOrderID)
        {
            InitializeComponent();
            gelenOrderID = secilenOrderID;
            gelenOrder = db.Orders.Find(gelenOrderID);
        }

        private void FormOrderHeaderDetail_Load(object sender, EventArgs e)
        {
            ComboDoldur();
            OrderDoldur();
            OrderDetDoldur();


        }

        private void ComboDoldur()
        {
            var clist = db.Customers.Select(x => new
            {
                x.CustomerID,
                x.CompanyName
            }).ToList();
            cmbCustomer.DataSource = clist;
            cmbCustomer.DisplayMember = "CompanyName";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.SelectedValue = gelenOrder.CustomerID;

            var elist = db.Employees.Select(x => new
            {
                x.EmployeeID,
                FullName = x.FirstName + " " + x.LastName
            }).ToList();
            cmbEmployee.DataSource = elist;
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "EmployeeID";
            cmbEmployee.SelectedValue = gelenOrder.EmployeeID;

            cmbShipVia.DataSource = db.Shippers.ToList();
            cmbShipVia.DisplayMember = "CompanyName";
            cmbShipVia.ValueMember = "ShipperID";
        }

        private void OrderDoldur()
        {
            txtOrderID.Text = gelenOrderID.ToString();
            dateOrder.Value = gelenOrder.OrderDate.Value;
            dateRequired.Value = gelenOrder.RequiredDate.Value;
            txtFreight.Text = gelenOrder.Freight.ToString();
            txtAddress.Text = gelenOrder.Customer.Address;
            txtCountry.Text = gelenOrder.Customer.City + "/" + gelenOrder.Customer.Country;
        }

        private void OrderDetDoldur()
        {
            var odList = db.Order_Details.Where(x => x.OrderID == gelenOrderID).Select(x => new
            {
                x.OrderID,
                x.ProductID,
                x.Product.ProductName,
                x.Quantity,
                x.UnitPrice,
                Total = x.Quantity * x.UnitPrice
            }).ToList();

            dataGridView1.DataSource = odList;
            txtTotalOrder.Text = odList.Sum(x => x.Total).ToString();

            var plist = db.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName
            }).ToList();

            cmbProducts.DataSource = plist;
            cmbProducts.DisplayMember = "ProductName";
            cmbProducts.ValueMember = "ProductID";

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormGiris frm = new FormGiris();
            frm.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnInsertDetail_Click(object sender, EventArgs e)
        {
            try
            {


                Order_Detail od = new Order_Detail();
                od.OrderID = Convert.ToInt32(txtOrderID.Text);
                od.ProductID = (int)cmbProducts.SelectedValue;
                od.Quantity = Convert.ToInt16(txtQuantity.Text);

                Product p = db.Products.Find(od.ProductID);
                od.UnitPrice = (decimal)p.UnitPrice;
                db.Order_Details.Add(od);
                db.SaveChanges();
                od.Discount = 0;
                OrderDetDoldur();
                MessageBox.Show("Insert is successfully");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdateDetail_Click(object sender, EventArgs e)
        {
            try
            {
                db.Order_Details.Remove(secilenOrderDet);

                Order_Detail od = new Order_Detail();
                od.OrderID = Convert.ToInt32(txtOrderID.Text);
                od.ProductID = (int)cmbProducts.SelectedValue;
                od.Quantity = Convert.ToInt16(txtQuantity.Text);

                Product p = db.Products.Find(od.ProductID);
                od.UnitPrice = (decimal)p.UnitPrice;
                db.Order_Details.Add(od);
                db.SaveChanges();
                od.Discount = 0;
                OrderDetDoldur();
                MessageBox.Show("Update is successfully");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            secilenProductID = (int)dataGridView1.CurrentRow.Cells["ProductID"].Value;
            secilenOrderDet = db.Order_Details.Find(gelenOrderID, secilenProductID);
            txtQuantity.Text = secilenOrderDet.Quantity.ToString();
            cmbProducts.SelectedValue = secilenProductID;

        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            try
            {
                db.Order_Details.Remove(secilenOrderDet);
                db.SaveChanges();
                OrderDetDoldur();
                MessageBox.Show("Delete is successfully");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                db.Orders.Remove(gelenOrder);
                db.SaveChanges();
                MessageBox.Show("Orders has been deleted");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {

            try
            {
                gelenOrder.CustomerID = cmbCustomer.SelectedValue.ToString();
                gelenOrder.EmployeeID = (int)cmbEmployee.SelectedValue;
                gelenOrder.OrderDate = dateOrder.Value;
                gelenOrder.RequiredDate = dateRequired.Value;
                gelenOrder.ShipVia = (int)cmbShipVia.SelectedValue;
                gelenOrder.Freight = Convert.ToDecimal(txtFreight.Text);
                db.SaveChanges();
                MessageBox.Show("Order has been Updated.");
                OrderDoldur();
                ComboDoldur();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
