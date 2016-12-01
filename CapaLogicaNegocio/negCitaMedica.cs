using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class negCitaMedica
    {
        #region singleton
        private static readonly negCitaMedica _instancia = new negCitaMedica();
        public static negCitaMedica Instancia
        {
            get { return negCitaMedica._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entCitaMedica> ListarCitasMedicas() {
            try
            {
                return datCitaMedica.Instancia.ListarCitasMedicas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean InsertarCitaMedica(entCitaMedica c)
        {
            try
            {
                return datCitaMedica.Instancia.InsertarCitaMedica(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public entCitaMedica ObtenerCitaMedica(Int16 idCitaMedica)
        {
            try
            {
                return datCitaMedica.Instancia.ObtenerCitaMedica(idCitaMedica);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EiminarCitaMedica(Int16 IdCitaMedica)
        {
            try
            {
                return datCitaMedica.Instancia.EiminarCitaMedica(IdCitaMedica);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Int32 ListarCantidadCitas()
        {
            try
            {
                return datCitaMedica.Instancia.ListarCantidadCitas();
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        #endregion metdos
    }
}
