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
                        entPersona p = new entPersona();
                        p.idPersona = Convert.ToInt32(dr["IDPERSONA"].ToString());
                        p.Nombres = dr["NOMBRES"].ToString();
                        p.Apellidos = dr["APELLIDOS"].ToString();
                        p.Direccion = dr["DIRECCION"].ToString();
                    u.UserName = dr["USERNAME"].ToString();
                    u.Persona = p;
                        entTipoUsuario tp = new entTipoUsuario();
                        tp.Nombre = dr["TIPOUSUARIO"].ToString();
                    u.TipoUsuario = tp;
                    u.Estado  = Convert.ToBoolean(dr["ESTADO"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return u;
        }

        public entUsuario ObtenerUsuario(Int16 idUsario)
        {
            SqlCommand cmd = null;
            entUsuario u = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spObtenerUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmidUsuario", idUsario);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new entUsuario();
                    u.idUsuario = Convert.ToInt16(dr["IDUSUARIO"]);
                    entPersona p = new entPersona();
                    p.idPersona = Convert.ToInt32(dr["IDPERSONA"].ToString());
                    p.Nombres = dr["NOMBRES"].ToString();
                    p.Apellidos = dr["APELLIDOS"].ToString();
                    p.Direccion = dr["DIRECCION"].ToString();
                    p.Telefono = dr["TELEFONO"].ToString();
                    u.UserName = dr["USERNAME"].ToString();
                    u.Password = dr["PASSWORD"].ToString();
                    u.Persona = p;
                    entTipoUsuario tp = new entTipoUsuario();
                    tp.Nombre = dr["TIPOUSUARIO"].ToString();
                    u.TipoUsuario = tp;
                    u.Estado = Convert.ToBoolean(dr["ESTADO"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return u;
        }

        public Boolean EditarUsuario(entUsuario u)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spModificarPerfil", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdpersona", u.Persona.idPersona);
                cmd.Parameters.AddWithValue("@prmIdusuario", u.idUsuario);
                cmd.Parameters.AddWithValue("@prmNombres", u.Persona.Nombres);
                cmd.Parameters.AddWithValue("@prmApellidos", u.Persona.Apellidos);
                cmd.Parameters.AddWithValue("@prmDireccion", u.Persona.Direccion);
                cmd.Parameters.AddWithValue("@prmTelefono", u.Persona.Telefono);
                cmd.Parameters.AddWithValue("@prmUsername", u.UserName);
                cmd.Parameters.AddWithValue("@prmPassword", u.Password);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception ex) { throw ex; }
            return inserto;
        }
        #endregion metodos
    }
}
