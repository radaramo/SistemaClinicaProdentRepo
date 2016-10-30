using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia
        {
            get { return Conexion._instancia; }
        }
        #endregion singleton

        #region metodos
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=diarsramirezmontes.database.windows.net; Initial Catalog=SistemaClinica;" +
                                "User ID=rramirez; Password=Raul1995";
            //cn.ConnectionString = "Data Source=.; Initial Catalog=SistemaClinica;" +
            //                   "Integrated Security=true";
            ////"User ID=sa; Password=123";
            return cn;
        }
        #endregion metodos


    }
}
