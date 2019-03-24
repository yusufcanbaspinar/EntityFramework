namespace EF_CodeFirst_CokaCokIliski
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;
   
using System.ComponentModel.DataAnnotations.Schema;

    public class UniversiteContext : DbContext
    {
        // Your context has been configured to use a 'UniversiteContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EF_CodeFirst_CokaCokIliski.UniversiteContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'UniversiteContext' 
        // connection string in the application configuration file.
        public UniversiteContext()
            : base("name=UniversiteContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Egitmen> Egitmenler { get; set; }
        public virtual DbSet<Ogrenci> Ogrenciler { get; set; }
    }
    [Table ("Egitmenler") ]
    public class Egitmen
    {
        public Egitmen()
        {
            this.Ogrenciler = new HashSet<Ogrenci>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public virtual ICollection<Ogrenci> Ogrenciler { get; set; }
    }
    [Table("Ogrenciler")]
    public class Ogrenci
    {
        public Ogrenci()
        {
            this.Egitmenler = new HashSet<Egitmen>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public virtual ICollection<Egitmen> Egitmenler { get; set; }
    }
}