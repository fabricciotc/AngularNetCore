using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class HomeworkUpload
    {
        [Key]
        public int HomeworkUploadId { set; get; }
        [StringLength(45)]
        public DateTime Upload { set; get; }
        public byte[] Content { set; get; }
        public int HomeworkId { set; get; }
        [ForeignKey("HomeworkId")]
        public Homework homework { set; get; }
        public int StudentId { set; get; }
        [ForeignKey("StudentId")]
        public User student { set; get; }
        //PROPIEDADES NAVIGACIONALES
        public List<Qualification> Qualifications { set; get; }
    }
}
