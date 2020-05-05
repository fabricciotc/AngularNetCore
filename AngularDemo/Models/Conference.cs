using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class Conference
    {
        [Key]
        public int ConferenceId { set; get; }
        [StringLength(45)]
        public string Meeting_Id { set; get; }
        [StringLength(45)]
        public string Meeting_Pass { set; get; }
        public int CourseId { set; get; }
        [ForeignKey("CourseId")]
        public Course course { set; get; }
    }
}
