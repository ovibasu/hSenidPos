using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPos.Shared.Models
{
    public class BillMaster
    {
        [Key]
        public int BillMasterId { get; set; }
        [StringLength(50)]
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime BillTime { get; set; }
        public decimal SubTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal VAT { get; set; }
        public decimal GrandTotal { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public IEnumerable<BillDetails> BillDetails { get; set; }
    }
}
