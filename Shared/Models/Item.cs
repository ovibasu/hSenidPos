using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPos.Shared.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required(ErrorMessage ="Item Name is Required?")]
        [StringLength(55)]
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public IEnumerable<BillDetails> BillDetails { get; set; }
    }
}
