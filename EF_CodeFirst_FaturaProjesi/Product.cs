using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_FaturaProjesi
{
    public class Product
    {
        public Product()
        {
            this.invoiceDetails = new HashSet<InvoiceDetail>();
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public int ProductNumber { get; set; }

        public int UnitPrice { get; set; }

        public int UnitID { get; set; }
        public virtual Unit Unit { get; set; }

        public virtual ICollection<InvoiceDetail> invoiceDetails { get; set; }
    }
}
