using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class negUsuario
    {
        #region singleton
        private static readonly negUsuario _instancia = new negUsuario();
        public static negUsuario Instancia
        {
            get { return negUsuario._instancia; }
        }
        #endregion singleton
        #region metodos
        public entUsuario VerificarAcceso(String _Usuario, String _Password)
        {
            try
            {
                entUsuario u = datUsuario.Instancia.VerificarAcceso(_Usuario, _Password);
                if (u == null)
                {
                    throw new ApplicationException("Usuario o Password no valido");
                }
                else if (!u.Estado  )
                {
                    throw new ApplicationException("Su usuario ha sido dado de baja");
                }
                return u;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion metodos
    }
}
