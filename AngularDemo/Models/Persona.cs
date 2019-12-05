using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class Persona
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Direccione> Direcciones { set; get; }
    }
}
