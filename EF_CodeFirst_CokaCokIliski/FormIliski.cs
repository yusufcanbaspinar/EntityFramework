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

namespace EF_CodeFirst_CokaCokIliski
{
    public partial class FormIliski : Form
    {
        public FormIliski()
        {
            InitializeComponent();
        }
        UniversiteContext db = Dbsingletone.GetInstance();
        private void FormIliski_Load(object sender, EventArgs e)
        {
            //ComboDoldur();
            //ListDoldur();
            Doldur();
        }
        public void ComboDoldur()
        {
            var elist = db.Egitmenler.Select(x => new
            {
                FullName = x.Ad + " " + x.Soyad,
                x.Id,
                x.Ogrenciler
            }).ToList();

            cmbEgitmen.DisplayMember = "FullName";
            cmbEgitmen.ValueMember = "Id";
            cmbEgitmen.DataSource = elist;
        }

        public void ListDoldur()
        {
            var olist = db.Ogrenciler.Select(x => new
            {
                FullName = x.Ad + " " + x.Soyad,
                x.Id,
                x.Egitmenler

            }).ToList();

            lstOgrenci.DisplayMember = "FullName";
            lstOgrenci.ValueMember = "Id";
            lstOgrenci.DataSource = olist;
        }

        public void Doldur()
        {
            lstOgrenci.DisplayMember = "Ad";
            lstOgrenci.DataSource = db.Ogrenciler.ToList();
            cmbEgitmen.DisplayMember = "Ad";
            cmbEgitmen.DataSource = db.Egitmenler.ToList();
        }
        private void btnIliski_Click(object sender, EventArgs e)
        {
            Egitmen seciliEgitmen = cmbEgitmen.SelectedItem as Egitmen;
            var egitmen = db.Egitmenler.Find(seciliEgitmen.Id);
            foreach (Ogrenci item in lstOgrenci.SelectedItems)
            {
                egitmen.Ogrenciler.Add(item);
            }
            db.SaveChanges();
            lstOgrenci.SelectedItems.Clear();
            dataGridView1.DataSource = egitmen.Ogrenciler.ToList();
        }
        private void cmbEgitmen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Egitmen seciliEgitmen = cmbEgitmen.SelectedItem as Egitmen;
            var egitmeninOgrencileri = db.Egitmenler.Find(seciliEgitmen.Id).Ogrenciler.ToList();
            dataGridView1.DataSource = egitmeninOgrencileri;
        }
    }
}
