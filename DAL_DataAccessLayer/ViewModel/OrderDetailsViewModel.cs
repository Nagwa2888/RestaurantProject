using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DataAccessLayer.ViewModel
{
    public class OrderDetailsViewModel
    {
        public int ID { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Quantity { get; set; }

        public virtual OrderViewModel Order { get; set; }
    }
}
