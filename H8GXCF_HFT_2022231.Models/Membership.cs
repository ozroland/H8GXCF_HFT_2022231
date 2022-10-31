using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Models
{
    public enum Category
    {
        Student,
        Normal,
        Retired
    }
    [Table("membership")]
    public class Membership : Entity
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public int HowLong { get; set; }
        public Category Category { get; set; }
    }
}
