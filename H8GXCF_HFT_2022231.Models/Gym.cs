using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Models
{
    [Table("gym")]
    public class Gym : Entity
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
