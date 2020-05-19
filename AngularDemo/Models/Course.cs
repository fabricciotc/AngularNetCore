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
        public string ClassroomID { set; get; }
        public string ClassroomPASS { set; get; }
        public string TeacherName { set; get; }
        public int SedeId { set; get; }
        //PROPIEDADES DE NAVEGACION
        public List<Schedule> Schedules { set; get; }
        public List<CourseBuy> Students { set; get; }

    }
}
