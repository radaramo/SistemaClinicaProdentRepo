using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entPaciente
    {
     public int idPaciente { get; set; }
     public String Nombres { get; set; }
     public String Apellidos { get; set; }
     public String Dni { get; set; }
     public String Direccion { get; set; }
     public DateTime FechaNacimiento { get; set; }
     public String Edad { get; set; }
     public String Sexo { get; set; }
     public String Correo { get; set; }
     public String Telefono { get; set; }
     public String Celular { get; set; }
     public Boolean Estado { get; set; }
    }
}
