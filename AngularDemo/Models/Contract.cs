using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class Contract
    {
        [Key]
        public int ContractId { set; get; }
        [StringLength(30)]
        public string Status { set; get; }
        public DateTime Created { set; get; }
        public DateTime Modificated { set; get; }
        public string TeacherId { set; get; }
        [ForeignKey("TeacherId")]
        public User teacher { set; get; }
        public int CollegeId { set; get; }
        [ForeignKey("CollegeId")]
        public College college { set; get; }
    }
}
