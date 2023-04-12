using Day09.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09_remake.Models
{
    public class TCID
    {
        public int CourseID { get; set; }
        public int TraineeID { get; set; }
    }
    public class TraineeCourse
    {
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }
        public Grade Grade { get; set; }
        public virtual Trainee Trainee { get; set; }
        public virtual Course Course { get; set;}
    }
}
