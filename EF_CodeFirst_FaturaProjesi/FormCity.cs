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
    public partial class FormCity : Form
    {
        public FormCity()
        {
            InitializeComponent();
        }
        InvoiceProjectContext db = DbSingletone.GetInstance();
        int secilenID;
        List<int> SilinecekID;
        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                City c = new City();
                c.CityName = txtCityName.Text;
                db.Cities.Add(c);
                db.SaveChanges();
                List();
                txtCityName.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public void List()
        {
            dataGridView1.DataSource = db.Cities.ToList();
            dataGridView1.Focus();
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            txtCityName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                City city = db.Cities.Find(secilenID);
                city.CityName = txtCityName.Text;
                db.SaveChanges();
                List();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void FormCity_Load(object sender, EventArgs e)
        {
            List();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                City city = db.Cities.Find(secilenID);
                db.Cities.Remove(city);
                db.SaveChanges();
                List();
                txtCityName.Text = string.Empty;
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
                        City city = db.Cities.Find(item);
                        db.Cities.Remove(city);
                        db.SaveChanges();
                        List();
                        txtCityName.Text = string.Empty;
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
