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
    public partial class FormUnit : Form
    {
        public FormUnit()
        {
            InitializeComponent();
        }

        InvoiceProjectContext db = DbSingletone.GetInstance();
        int SecilenUnitID;
        List<int> SilinecekID;
        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Unit unit = new Unit();
            unit.UnitName = txtUnitName.Text;
            db.Units.Add(unit);
            db.SaveChanges();
            List();
            txtUnitName.Text = string.Empty;
        }
        public void List()
        {
            dataGridView1.DataSource = db.Units.Select(x => new
            {
                x.UnitID,
                x.UnitName
            }).ToList();
        }

        private void FormUnit_Load(object sender, EventArgs e)
        {
            List();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SecilenUnitID =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            txtUnitName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Unit unit = db.Units.Find(SecilenUnitID);
            unit.UnitName = txtUnitName.Text;
            db.SaveChanges();
            List();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Unit unit = db.Units.Find(SecilenUnitID);
            db.Units.Remove(unit);
            db.SaveChanges();
            List();
            txtUnitName.Text = string.Empty;
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
                        Unit unit = db.Units.Find(item);
                        db.Units.Remove(unit);
                        db.SaveChanges();
                        List();
                        txtUnitName.Text = string.Empty;
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
