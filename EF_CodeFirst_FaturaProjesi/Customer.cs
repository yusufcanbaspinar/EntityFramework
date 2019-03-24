using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_FaturaProjesi
{
    public class Customer
    {
        public Customer()
        {
            this.invoiceHeaders = new HashSet<InvoiceHeader>();
        }
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public int CountyID { get; set; }
        public virtual County county { get; set; }
        public string Adrress { get; set; }
        public virtual ICollection<InvoiceHeader> invoiceHeaders { get; set; }
    }
}
