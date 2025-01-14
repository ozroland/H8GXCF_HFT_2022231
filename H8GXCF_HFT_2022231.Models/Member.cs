﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    [Table("member")]
    public class Member
    {
        public Member()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Contact { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [NotMapped]
        public virtual Membership Membership { get; set; }
        [ForeignKey(nameof(Membership))]
        public int MembershipID { get; set; }
        [NotMapped]
        public virtual Instructor Instructor { get; set; }
        [ForeignKey(nameof(Instructor))]
        public int InstructorID { get; set; }
    }
}