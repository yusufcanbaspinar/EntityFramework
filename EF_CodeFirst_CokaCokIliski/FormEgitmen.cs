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
    public partial class FormEgitmen : Form
    {
        public FormEgitmen()
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Egitmen eg = new Egitmen();
            eg.Ad = txtAd.Text;
            eg.Soyad = txtSoyad.Text;
            db.Egitmenler.Add(eg);
            db.SaveChanges();
            Doldur();
        }

        public void Doldur()
        {
            
            //var elist = db.Egitmenler.Select(x => new MyEnt
            //{
            //    EgitmenID = x.Id,
            //    Ad = x.Ad,
            //    Soyad = x.Soyad
            //}).ToList();
            //dataGridView1.DataSource = elist;
           

            
            var elist2 = db.Egitmenler.ToList();
            dataGridView1.DataSource = elist2;
           
            
        }

        private void FormEgitmen_Load(object sender, EventArgs e)
        {
            Doldur();
        }
    }
}
