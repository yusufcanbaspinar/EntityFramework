using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_FaturaProjesi
{
    class DbSingletone
    {
        private static InvoiceProjectContext db;

        public static InvoiceProjectContext GetInstance()
        {
            if (db == null)
            {
                db = new InvoiceProjectContext();
            }
            return db;
        }
    }
}
