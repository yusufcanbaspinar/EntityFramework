namespace EF_CodeFirst_FaturaProjesi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF_CodeFirst_FaturaProjesi.InvoiceProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EF_CodeFirst_FaturaProjesi.InvoiceProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //    context.Cities.AddOrUpdate(x => x.CityID,
            //new City() { CityName = "Ankara" },
            //new City() {  CityName = "Bursa" },
            //new City() { CityName = "İstanbul" }
            //);

            

        }
    }
}
