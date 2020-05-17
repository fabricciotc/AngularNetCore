using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class Course
    {
        [Key]
        public int CourseId { set; get; }
        [StringLength(45)]
        public string Name { set; get; }
        [StringLength(20)]
        public string Classroom { set; get; }
        public int CollegeId { set; get; }
        public string TeacherId { set; get; }
        [ForeignKey("TeacherId")]
        public User teacher { set; get; }
        public int SedeId { set; get; }
        //PROPIEDADES DE NAVEGACION
        public List<Enroll> Students { set; get; }

    }
}
