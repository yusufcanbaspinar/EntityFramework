using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CodeFirst_CokaCokIliski
{
    public partial class FormOgrenci : Form
    {
        public FormOgrenci()
        {
            InitializeComponent();
        }
        UniversiteContext db = Dbsingletone.GetInstance();
        private void btnGeri_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void FormOgrenci_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        public void Doldur()
        {
            dataGridView1.DataSource = db.Ogrenciler.Select(x => new
            {
                x.Id,
                x.Ad,
                x.Soyad
            }).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ogrenci og = new Ogrenci();
            og.Ad = txtAd.Text;
            og.Soyad = txtSoyad.Text;
            db.Ogrenciler.Add(og);
            db.SaveChanges();
            Doldur();
        }
    }
}
