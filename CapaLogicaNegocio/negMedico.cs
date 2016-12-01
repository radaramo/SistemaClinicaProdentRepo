using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
   public  class negMedico
    {
        #region singleton
       private static readonly negMedico _instancia = new negMedico();
       public static negMedico Instancia
        {
            get { return negMedico._instancia; }
        }
        #endregion singleton

        #region metodos
       public List<entMedico> ListarMedicos()
       {
           try
           {
               return datMedico.Instancia.ListarMedico();
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

        #endregion metodos
    }
}
