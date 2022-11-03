using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Models
{
    [Table("workoutplan")]
    public class WorkoutPlan : Entity
    {
        [NotMapped]
        public virtual Member Member { get; set; }
        [ForeignKey(nameof(Member))]
        public int MemberID { get; set; }
        [NotMapped]
        public virtual Workout Workout { get; set; }
        [ForeignKey(nameof(Workout))]
        public int WorkoutID { get; set; }
        [Required]
        public int WorkoutTimeInMinutes { get; set; }
        public DateTime WorkoutDate { get; set; }
        [NotMapped]
        public virtual Instructor Instructor { get; set; }
        [ForeignKey(nameof(Instructor))]
        public int InstructorID { get; set; }
    }
}
