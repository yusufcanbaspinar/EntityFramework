using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_FaturaProjesi
{
    public class County
    {
        public County()
        {
            this.customers = new HashSet<Customer>();
        }
        public int CountyID { get; set; }
        public string CountyName { get; set; }
        public int CityID { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Customer> customers { get; set; }
    }
}
