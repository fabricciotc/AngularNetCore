using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class Sede
    {
        [Key]
        public int SedeId { set; get; }
        public int AddressId { set; get; }
        [ForeignKey("AddressId")]
        public Address address { set; get; }
        public string DisplayName { set; get; }
    }
}
