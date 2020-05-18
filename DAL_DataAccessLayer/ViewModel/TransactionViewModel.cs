using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DataAccessLayer.ViewModel
{
    class TransactionViewModel
    {
        public int ID { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<int> TypeId { get; set; }
    }
}
