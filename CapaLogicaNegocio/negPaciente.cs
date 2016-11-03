using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class negPaciente
    {
        #region singleton
        private static readonly negPaciente _instancia = new negPaciente();
        public static negPaciente Instancia
        {
            get { return negPaciente._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<entPaciente> ListarPaciente()
        {
            try
            {
                return datPaciente.Instancia.ListarPaciente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean InsertarPaciente(entPaciente p)
        {
            try
            {
                return datPaciente.Instancia.InsertarPaciente(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public entPaciente ObtenerPaciente(Int16 idPaciente)
        {
            try
            {
                return datPaciente.Instancia.ObtenerPaciente(idPaciente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EiminarPaciente(Int16 idPaciente) {
            try
            {
                return datPaciente.Instancia.EiminarPaciente(idPaciente);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        #endregion metodos
    }
}
