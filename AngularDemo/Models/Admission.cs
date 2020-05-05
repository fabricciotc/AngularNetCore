using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class Admission
    {
        [Key]
        public int AdmissionId { set; get; }
        [StringLength(30)]
        public string Status { set; get; }
        public DateTime Created { set; get; }
        public DateTime Modificated { set; get; }
        public int CollegeId { set; get; }
        public string StudentId { set; get; }
        [ForeignKey("StudentId")]
        public User Student { set; get; }

    }
}
