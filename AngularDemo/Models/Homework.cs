using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { set; get; }
        [StringLength(30)]
        public string Title { set; get; }
        public string Description { set; get; }
        public DateTime Created { set; get; }
        public DateTime Expired { set; get; }
        public int Chance { set; get; }
        public int CourseId { set; get; }
        [ForeignKey("CourseId")]
        public Course course { set; get; }
        public string TeacherId { set; get; }
        //PROPIEDADES DE NAVEGACION
        List<HomeworkUpload> HomeworkUploads { set; get; }
    }
}
