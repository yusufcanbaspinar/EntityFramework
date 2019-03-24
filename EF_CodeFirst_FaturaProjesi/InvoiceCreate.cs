using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_FaturaProjesi
{
    public class InvoiceCreate
    {
       

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalAmount { get; set; }
        public int VATAmount { get; set; }
        public int TotalAmountWithVAT { get; set; }
        public string Description { get; set; }

    }
}
