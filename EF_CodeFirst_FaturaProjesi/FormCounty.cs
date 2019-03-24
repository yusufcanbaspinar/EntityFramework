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
    public partial class FormCounty : Form
    {
        public FormCounty()
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

        private void FormCounty_Load(object sender, EventArgs e)
        {
            cmbCity.DisplayMember = "CityName";
            cmbCity.ValueMember = "CityID";
            cmbCity.SelectedIndex = -1;
            cmbCity.DataSource = db.Cities.ToList();
            List();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                County county = new County();
                county.CountyName = txtCountyName.Text;
                county.CityID = (int)cmbCity.SelectedValue;
                db.Counties.Add(county);
                db.SaveChanges();
                List();
                txtCountyName.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public void List()
        {
            dataGridView1.DataSource = db.Counties.Select(x => new
            {
                x.CountyID,
                x.CountyName,
                x.City.CityName
            }).ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCountyName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            secilenID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                County county = db.Counties.Find(secilenID);
                county.CountyName = txtCountyName.Text;
                county.CityID = (int)cmbCity.SelectedValue;
                db.SaveChanges();
                List();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                County county = db.Counties.Find(secilenID);
                db.Counties.Remove(county);
                db.SaveChanges();
                List();
                txtCountyName.Text = string.Empty;
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
                        County county = db.Counties.Find(item);
                        db.Counties.Remove(county);
                        db.SaveChanges();
                        List();
                        txtCountyName.Text = string.Empty;
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
