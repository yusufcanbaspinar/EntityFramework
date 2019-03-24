using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountingSystemModelContainer db = new AccountingSystemModelContainer();
            InvoiceHeader invHead = db.InvoiceHeaders.Create();
            invHead.Total = 2261m;

            InvoiceDetail invDetail = db.InvoiceDetails.Create();
            invDetail.ItemDescription = "Our first model first";
            invDetail.Quantity = 19;
            invDetail.Price = 119m;

            invHead.InvoiceDetail.Add(invDetail);

            db.InvoiceHeaders.Add(invHead);

            db.SaveChanges();
        }
    }
}
