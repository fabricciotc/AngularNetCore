using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class User: IdentityUser
    {
        [StringLength(30)]
        [Required]
        public string FirstName { set; get; }
        [StringLength(40)]
        [Required]
        public string LastNames { set; get; }
        [StringLength(20)]
        public string NUM_DOC { set; get; }
        [Required]
        public DateTime Birthday { set; get; }
        [Required]
        public bool Sex { set; get; }
        public byte[] Photo { set; get; }
        public int? AddressId { set; get; } 
        [ForeignKey("AddressId")]
        public Address address { set; get; }
        //PROPIEDAD NAVIGACIONAL STUDENT
        public virtual List<Enroll> Enrolles { set; get; }
        public virtual List<Admission> Admissions { set; get; }
        //PROPIEDAD NAVIGACIONAL TEACHER
        public virtual List<Course> Courses { set; get; }
        public virtual List<Contract> Contacts { set; get; }

    }
}
