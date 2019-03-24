using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DatabaseFirst
{
    public class DbSingleTone
    {
        private static NorthwindEntitiesConnectionString db;
        public static NorthwindEntitiesConnectionString GetInstance()
        {
            if(db==null)
            {
                db = new NorthwindEntitiesConnectionString();
            }
            return db;
        }
    }
}
