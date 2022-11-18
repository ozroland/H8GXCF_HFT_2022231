using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Models
{
    [Table("membership")]
    public class Membership : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int SignupFee { get; set; }
        [NotMapped]
        public virtual ICollection<Member> Members { get; set; }
    }
}
