using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { set; get; }
        [ForeignKey("CourseId")]
        public Course course { set; get; }
        public int CourseId { set; get; }
        public string Day { set; get; }
        public string Start { set; get; }
        public string Finish { set; get; }

    }
}