using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entCitaMedica
    {
        public int idCitaMedica { get; set; } 
        public DateTime Fecha { get; set; }
        public String Hora { get; set; }
        public String Descripcion { get; set; }
        public int TipoConsulta { get; set; }
        public int EstadoCita { get; set; }
        public Boolean Estado {get;set;}
        public entPaciente Paciente { get; set; }
        public entMedico Medico { get; set; }

    }
}
