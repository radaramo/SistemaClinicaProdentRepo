using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
   public class entMedico
    {
        public int idMedico { get; set; }
        public String Especilidad { get; set; }
        public entPersona Persona { get; set; }
    }
}
