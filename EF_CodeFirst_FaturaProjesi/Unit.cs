﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_FaturaProjesi
{
    public class Unit
    {
        public Unit()
        {
            this.products = new HashSet<Product>();
        }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
}
