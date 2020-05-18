using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DataAccessLayer.ViewModel
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public int? CustomerId { get; set; }
        public int? PaymentTypeId { get; set; }
        public string OrderNumber { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal? FinalTotal { get; set; }
        public virtual ICollection<OrderDetailsViewModel> ListOfOrderDetailsViewModel { get; set; }

    }
}
