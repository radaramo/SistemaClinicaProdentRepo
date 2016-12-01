using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entConsultaMedica
    {
        public int idConsultaHistorial { get; set; }
        public String Sintomas { get; set; }
        public String Examenes { get; set; }
        public String Tratamiento { get; set; }
        public String Observaciones { get; set; }
        public DateTime Fecha { get; set; }
        public entPaciente Paciente { get; set; }
        public entCitaMedica CitasMedicas { get; set; }

    }
}
