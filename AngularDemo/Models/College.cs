using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class College
    {
        [Key]
        public int CollegeId { set; get; }
        [StringLength(45)]
        public string Name { set; get; }
        [StringLength(20)]
        public string Nationality { set; get; }
        [StringLength(40)]
        public string Phone { set; get; }

        //PROPIEDADES NAVIGACIONALES
        public List<Admission> Students { set; get; }
        public List<Contract> Teachers { set; get; }
        public List<Sede> Sedes { set; get; }
    }
}
