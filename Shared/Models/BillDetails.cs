using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPos.Shared.Models
{
    public class BillDetails
    {
        [Key]
        public int BillDetailsId { get; set; }
        public int BillMasterId { get; set; }
        public BillMaster BillMaster { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
