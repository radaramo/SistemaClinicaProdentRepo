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
    public class datCitaMedica
    {
        #region singleton
        private static readonly datCitaMedica _instancia = new datCitaMedica();
        public static datCitaMedica Instancia
        {
            get { return datCitaMedica._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entCitaMedica> ListarCitasMedicas()
        {
            SqlCommand cmd = null;
            List<entCitaMedica> lista = new List<entCitaMedica>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarCitasMedicas", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entCitaMedica c = new entCitaMedica();
                    c.idCitaMedica = Convert.ToInt32(dr["IDCITAMEDICA"]);
                        entPaciente p = new entPaciente();
                        p.idPaciente = Convert.ToInt32(dr["IDPACIENTE"]);
                        p.Nombres = dr["PACIENTE"].ToString();
                    c.Paciente = p;
                        entMedico m = new entMedico();
                        m.idMedico = Convert.ToInt32(dr["IDMEDICO"]);
                             entPersona ps = new entPersona();
                             ps.Nombres = dr["MEDICO"].ToString();
                        m.Persona = ps;
                    c.Medico = m;
                    c.Fecha = Convert.ToDateTime(dr["FECHA"].ToString());
                    c.Hora = dr["HORA"].ToString();
                    c.TipoConsulta = Convert.ToInt32(dr["TIPOCONSULTA"]);
                    c.EstadoCita = Convert.ToInt32(dr["ESTADOCITA"]);
                    lista.Add(c);
                }
            }
            catch (Exception ex) { throw ex; }
            return lista;
        }

        public Boolean InsertarCitaMedica(entCitaMedica c)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarCitaMedica", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmId", c.idCitaMedica);
                cmd.Parameters.AddWithValue("@prmIdPaciente", c.Paciente.idPaciente);
                cmd.Parameters.AddWithValue("@prmIdMedico", c.Medico.idMedico);
                cmd.Parameters.AddWithValue("@prmFecha", c.Fecha);
                cmd.Parameters.AddWithValue("@prmHora", c.Hora);
                cmd.Parameters.AddWithValue("@prmDescripcion", c.Descripcion);
                cmd.Parameters.AddWithValue("@prmTipoConsulta", c.TipoConsulta);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception ex) { throw ex; }
            return inserto;
        }

        public entCitaMedica ObtenerCitaMedica(Int16 idCitaMedica)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            entCitaMedica c = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spObtenerCitaMedicaxId", cn);
                cmd.Parameters.AddWithValue("@prmintIdCitaMedica", idCitaMedica);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c = new entCitaMedica();
                    c.idCitaMedica = Convert.ToInt16(dr["IDCITAMEDICA"]);
                        entPaciente p = new entPaciente();
                        p.idPaciente = Convert.ToInt16(dr["IDPACIENTE"]);
                        p.Nombres = dr["NOMBRES"].ToString();
                        p.Apellidos = dr["APELLIDOS"].ToString();
                        p.Edad = dr["EDAD"].ToString();
                    c.Paciente = p;
                        entMedico m = new entMedico();
                        m.idMedico = Convert.ToInt16(dr["IDMEDICO"]);
                    c.Medico = m;
                    c.Fecha = Convert.ToDateTime(dr["FECHA"]);
                    c.Hora = dr["HORA"].ToString();
                    c.Descripcion = dr["DESCRIPCION"].ToString();
                    c.TipoConsulta = Convert.ToInt16(dr["TIPOCONSULTA"]);
                    c.EstadoCita = Convert.ToInt16(dr["ESTADOCITA"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return c;
        }

        public Boolean EiminarCitaMedica(Int16 idCitaMedica)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarCitaMedica", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmId", idCitaMedica);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception ex) { throw ex; }
            return inserto;
        }


        public Int32 ListarCantidadCitas()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int success = -1;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarCantidadCitas", cn);
                cn.Open();
                success = (int)(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return success;
        }

        #endregion metdos
    }
}
