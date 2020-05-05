using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class Address
    {
        [Key]
        public int AddressId { set; get; }
        [StringLength(40)]
        public string City { set; get; }
        [StringLength(40)]
        public string Country { set; get; }
        [StringLength(40)]
        public string State { set; get; }
        [StringLength(45)]
        public string AddressDirection { set; get; }
        [StringLength(18)]
        public string AddressNumber { set; get; }
        public string ZipCode { set; get; }
    }
}
