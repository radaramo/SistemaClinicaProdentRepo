using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class negConsultaMedica
    {
        #region singleton
        private static readonly negConsultaMedica _instancia = new negConsultaMedica();
        public static negConsultaMedica Instancia
        {
            get { return negConsultaMedica._instancia; }
        }
        #endregion singleton
        #region metodos
        public List<entCitaMedica> ListarCitasMedicasMedicos(Int32 idPersona)
        {
            try
            {
                return datConsultasMedicas.Instancia.ListarCitasMedicasMedicos(idPersona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean InsertarConsultaHistorial(entConsultaMedica c)
        {
            try
            {
                return datConsultasMedicas.Instancia.InsertarConsultaHistorial(c);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public List<entConsultaMedica> ListarHistorialClinicoPaciente(Int32 idPaciente)
        {
            try
            {
                return datConsultasMedicas.Instancia.ListarHistorialClinicoPaciente(idPaciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 ListarCantidadConsultas()
        {
            try
            {
                return datConsultasMedicas.Instancia.ListarCantidadConsultas();
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public entConsultaMedica ObtenerHistorialClinico(Int16 idHistorial)
        {
            try
            {
                return datConsultasMedicas.Instancia.ObtenerHistorialClinico(idHistorial);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
                    
        #endregion metodos
    }
}
