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
    public class datPaciente
    {
        #region singleton
        private static readonly datPaciente _instancia = new datPaciente();
        public static datPaciente Instancia
        {
            get { return datPaciente._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<entPaciente> ListarPaciente()
        {
            SqlCommand cmd = null;
            List<entPaciente> lista = new List<entPaciente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarPacientes", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entPaciente m = new entPaciente();
                    m.idPaciente = Convert.ToInt32(dr["IDPACIENTE"]);
                    m.Nombres = dr["NOMBRES"].ToString();
                    m.Apellidos = dr["APELLIDOS"].ToString();
                    m.Dni = dr["DNI"].ToString();
                    m.Edad = dr["EDAD"].ToString();
                    m.Sexo = dr["SEXO"].ToString();
                    lista.Add(m);
                }
            }
            catch (Exception ex) { throw ex; }
            return lista;
        }

        //public Boolean InsertarPaciente(entPaciente p)
        //{
        //    SqlCommand cmd = null;
        //    Boolean inserto = false;
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spInsertarPaciente", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@prmId",p.idPaciente);
        //        cmd.Parameters.AddWithValue("@prmNombres", p.Nombres);
        //        cmd.Parameters.AddWithValue("@prmApellidos", p.Apellidos);
        //        cmd.Parameters.AddWithValue("@prmDni", p.Dni);
        //        cmd.Parameters.AddWithValue("@prmDireccion", p.Direccion);
        //        cmd.Parameters.AddWithValue("@prmFechaNacimiento", p.FechaNacimiento);
        //        cmd.Parameters.AddWithValue("@prmEdad", p.Edad);
        //        cmd.Parameters.AddWithValue("@prmSexo", p.Sexo);
        //        cmd.Parameters.AddWithValue("@prmCorreo", p.Correo);
        //        cmd.Parameters.AddWithValue("@prmTelefono", p.Telefono);
        //        cmd.Parameters.AddWithValue("@prmCelular", p.Celular);
        //        cn.Open();
        //        int i = cmd.ExecuteNonQuery();
        //        if (i > 0) { inserto = true; }
        //    }
        //    catch (Exception ex) { throw ex; }
        //    return inserto;
        //}
        public Boolean InsertarPaciente(entPaciente p)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarPaciente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmId", p.idPaciente);
                cmd.Parameters.AddWithValue("@prmNombres", p.Nombres);
                cmd.Parameters.AddWithValue("@prmApellidos", p.Apellidos);
                cmd.Parameters.AddWithValue("@prmDni", p.Dni);
                cmd.Parameters.AddWithValue("@prmDireccion", p.Direccion);
                cmd.Parameters.AddWithValue("@prmFechaNacimiento", p.FechaNacimiento);
                cmd.Parameters.AddWithValue("@prmEdad", p.Edad);
                cmd.Parameters.AddWithValue("@prmSexo", p.Sexo);
                cmd.Parameters.AddWithValue("@prmCorreo", p.Correo);
                cmd.Parameters.AddWithValue("@prmTelefono", p.Telefono);
                cmd.Parameters.AddWithValue("@prmCelular", p.Celular);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception ex) { throw ex; }
            return inserto;
        }

        public entPaciente ObtenerPaciente(Int16 idPaciente)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            entPaciente p = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spObtenerPacientexid", cn);
                cmd.Parameters.AddWithValue("@prmintIdPaciente", idPaciente);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    p = new entPaciente();
                    p.idPaciente = Convert.ToInt16(dr["IDPACIENTE"]);
                    p.Nombres = dr["NOMBRES"].ToString();
                    p.Apellidos = dr["APELLIDOS"].ToString();
                    p.Dni = dr["DNI"].ToString();
                    p.Direccion = dr["DIRECCION"].ToString();
                    p.FechaNacimiento = Convert.ToDateTime(dr["FECHANACIMIENTO"]);
                    p.Edad = dr["EDAD"].ToString();
                    p.Sexo = dr["SEXO"].ToString();
                    p.Correo = dr["CORREO"].ToString();
                    p.Telefono = dr["TELEFONO"].ToString();
                    p.Celular = dr["CELULAR"].ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return p;
        }

        public entPaciente ObtenerPacientexDNI(Int32 PacienteDNI)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            entPaciente p = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spObtenerPacientexDNI", cn);
                cmd.Parameters.AddWithValue("@prmintDNI", PacienteDNI);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    p = new entPaciente();
                    p.idPaciente = Convert.ToInt16(dr["IDPACIENTE"]);
                    p.Nombres = dr["NOMBRES"].ToString();
                    p.Apellidos = dr["APELLIDOS"].ToString();
                    p.Dni = dr["DNI"].ToString();
                    p.Direccion = dr["DIRECCION"].ToString();
                    p.FechaNacimiento = Convert.ToDateTime(dr["FECHANACIMIENTO"]);
                    p.Edad = dr["EDAD"].ToString();
                    p.Sexo = dr["SEXO"].ToString();
                    p.Correo = dr["CORREO"].ToString();
                    p.Telefono = dr["TELEFONO"].ToString();
                    p.Celular = dr["CELULAR"].ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return p;
        }


        public Boolean EiminarPaciente(Int16 idPaciente)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarPaciente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmId", idPaciente);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception ex) { throw ex; }
            return inserto;
        }

        public Int32 ListarCantidadPacientes() {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int success = -1;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarCantidadPacientes", cn);
                cn.Open();
                success = (int)(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return success;
        }

        public List<entPaciente> UltimosPacientesRegistrados()
        {
            SqlCommand cmd = null;
            List<entPaciente> lista = new List<entPaciente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarUltimosPacientes", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entPaciente m = new entPaciente();
                    m.idPaciente = Convert.ToInt32(dr["IDPACIENTE"]);
                    m.Nombres = dr["NOMBRES"].ToString();
                    m.Apellidos = dr["APELLIDOS"].ToString();
                    m.Dni = dr["DNI"].ToString();
                    m.Edad = dr["EDAD"].ToString();
                    m.Sexo = dr["SEXO"].ToString();
                    lista.Add(m);
                }
            }
            catch (Exception ex) { throw ex; }
            return lista;
        }
        #endregion metodos
    }
}
