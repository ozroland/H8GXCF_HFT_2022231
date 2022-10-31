using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Models
{
    public enum Sex
    {
        Male,
        Female
    }
    [Table("member")]
    public class Member : Entity
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
        [NotMapped]
        public virtual Gym Gym { get; set; }
        [ForeignKey(nameof(Gym))]
        public int GymID { get; set; }
        [ForeignKey(nameof(Member))]
        public int MembershipID { get; set; }
    }
}
