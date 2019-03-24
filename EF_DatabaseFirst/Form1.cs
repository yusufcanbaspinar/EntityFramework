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
    public partial class Form1 : Form
    {

        //sipariş girme,görüntülme ve düzenleme.
        public Form1()
        {
            InitializeComponent();
        }

        NorthwindEntitiesConnectionString db = DbSingleTone.GetInstance();
        Label lblOrderID = new Label();
        TextBox txtOrdersID = new TextBox();
        Button btnGonder = new Button();

        private void siparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void siparişGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGiris frm = new FormGiris();
            
            frm.Show();
            this.Hide();
        }

        private void siparişDüzeltmeGörüntülemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnGonder.Text = "Open Order";
            btnGonder.Name = "btnGonder";
            lblOrderID.Text = "Order No";
            
            flowLayoutPanel1.Controls.Add(lblOrderID);
            flowLayoutPanel1.Controls.Add(txtOrdersID);
            flowLayoutPanel1.Controls.Add(btnGonder);
            btnGonder.Click += new EventHandler(btnGonder_Click);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void btnGonder_Click(object sender, EventArgs e)
        {
            OrderCheck();
            
        }

        public void OrderCheck()
        {
            int secilenOrderID;
            try
            {
                secilenOrderID = Convert.ToInt32(txtOrdersID.Text);
            }
            catch (Exception)
            {

                secilenOrderID = 0;
            }
            
            List<Order> olist = db.Orders.Where(x => x.OrderID == secilenOrderID).ToList();
            if ( olist.Count==0)
            {
                MessageBox.Show("Girilen Id'de sipariş yok.");
            }
            else
            {
                FormOrderHeaderDetail frm = new FormOrderHeaderDetail(secilenOrderID);
                frm.Show();
                this.Hide();
            }
        }


    }
}
