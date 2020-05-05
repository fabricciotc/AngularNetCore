using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class Qualification
    {
        [Key]
        public int QualificationId { set; get; }
        public float Mark { set; get; }
        public string Note { set; get; }
        public DateTime Upload { set; get; }
        public int HomeworkUploadId { set; get; }
        [ForeignKey("HomeworkUploadId")]
        public HomeworkUpload homeworkUpload { set; get; }

    }
}
