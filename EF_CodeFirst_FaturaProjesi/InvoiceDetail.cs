using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_FaturaProjesi
{
    public class InvoiceDetail
    {
        [Key, Column(Order = 0)]
        public int InvoiceID { get; set; }
        public virtual InvoiceHeader InvoiceHeader { get; set; }

        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalAmount { get; set; }
        public int VATAmount { get; set; }
        public int TotalAmountWithVAT { get; set; }
        public string Description { get; set; }
    }
}
