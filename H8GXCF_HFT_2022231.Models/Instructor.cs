using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Models
{
    [Table("instructor")]
    public class Instructor
    {
        public Instructor()
        {
            Members = new HashSet<Member>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(11)]
        public string Contact { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Member> Members { get; set; }
    }
}
