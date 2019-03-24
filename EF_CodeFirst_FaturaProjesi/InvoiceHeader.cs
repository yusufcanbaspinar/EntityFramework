using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_FaturaProjesi
{
    public class InvoiceHeader
    {
        public InvoiceHeader()
        {
            this.invoiceDetails = new HashSet<InvoiceDetail>();
        }
        [Key]
        public int InvoiceID { get; set; }
        public DateTime InvoiceDateTime { get; set; }
        public int DeliveryNoteNumber { get; set; }
        public DateTime PaymentDateTime { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<InvoiceDetail> invoiceDetails { get; set; }
    }
}
