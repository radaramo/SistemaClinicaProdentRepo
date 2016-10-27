using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
   public  class datUsuario
    {
        #region singleton
        private static readonly datUsuario _instancia = new datUsuario();
        public static datUsuario Instancia
        {
            get { return datUsuario._instancia; }
        }
        #endregion singleton
        #region metodos
        public entUsuario VerificarAcceso(String _Usuario, String _Password)
        {
            SqlCommand cmd = null;
            entUsuario u = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spVerificarAcceso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsuario", _Usuario);
                cmd.Parameters.AddWithValue("@prmPassword", _Password);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new entUsuario();
                    u.idUsuario = Convert.ToInt16(dr["IDUSUARIO"]);
                    u.Nombres = dr["NOMBRES"].ToString();
                    u.Apellidos = dr["APELLIDOS"].ToString();
                    u.Direccion = dr["DIRECCION"].ToString();
                    u.FechaCreacion = Convert.ToDateTime(dr["FECHACREACION"].ToString());
                    u.FechaActualizacion = Convert.ToDateTime(dr["FECHAACTUALIZACION"].ToString());
                    u.UserName = dr["USERNAME"].ToString();
                    u.Estado  = Convert.ToBoolean(dr["ESTADO"]);
                    u.Imagen = dr["IMAGEN"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return u;
        }
        #endregion metodos
    }
}
