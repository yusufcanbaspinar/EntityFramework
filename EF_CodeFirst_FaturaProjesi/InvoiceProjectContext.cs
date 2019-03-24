namespace EF_CodeFirst_FaturaProjesi
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class InvoiceProjectContext : DbContext
    {
        // Your context has been configured to use a 'FaturaContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EF_CodeFirst_FaturaProjesi.FaturaContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FaturaContext' 
        // connection string in the application configuration file.
        public InvoiceProjectContext()
            : base("name=Baglanti")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    }

   
}