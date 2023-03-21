using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPos.Shared.ViewModels
{
    public class BillItem
    {
        public int BillDetailsId { get; set; }
        public int BillMasterId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
