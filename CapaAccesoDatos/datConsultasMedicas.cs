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
    public class datConsultasMedicas
    {
        #region singleton
        private static readonly datConsultasMedicas _instancia = new datConsultasMedicas();
        public static datConsultasMedicas Instancia
        {
            get { return datConsultasMedicas._instancia; }
        }
        #endregion singleton
        #region metodos
        public List<entCitaMedica> ListarCitasMedicasMedicos(Int32 idPersona)
        {
            SqlCommand cmd = null;
            List<entCitaMedica> lista = new List<entCitaMedica>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarCitasMedicaxMedicoxFecha", cn);
                cmd.Parameters.AddWithValue("@prmIdPersona", idPersona);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public Boolean InsertarConsultaHistorial(entConsultaMedica c)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarConsultaHistorial", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdPaciente", c.Paciente.idPaciente);
                cmd.Parameters.AddWithValue("@prmIdCitaMedica", c.CitasMedicas.idCitaMedica);
                cmd.Parameters.AddWithValue("@prmSintomas", c.Sintomas);
                cmd.Parameters.AddWithValue("@prmExamenes", c.Examenes);
                cmd.Parameters.AddWithValue("@prmTratamiento", c.Tratamiento);
                cmd.Parameters.AddWithValue("@prmObservaciones", c.Observaciones);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception ex) { throw ex; }
            return inserto;
        }

        public List<entConsultaMedica> ListarHistorialClinicoPaciente(Int32 idPaciente)
        {
            SqlCommand cmd = null;
            List<entConsultaMedica> lista = new List<entConsultaMedica>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spObtenerHistoriaClinicoPaciente", cn);
                cmd.Parameters.AddWithValue("@prmintIdPaciente", idPaciente);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entConsultaMedica c = new entConsultaMedica();
                    c.idConsultaHistorial = Convert.ToInt32(dr["IDHISTORIALCLINICO"]);
                    c.Fecha = Convert.ToDateTime(dr["FECHA"].ToString());
                    c.Sintomas = dr["SINTOMAS"].ToString();
                    c.Examenes = dr["EXAMENES"].ToString();
                    c.Tratamiento = dr["TRATAMIENTO"].ToString();
                    c.Observaciones = dr["OBSERVACIONES"].ToString();
                        entPaciente p = new entPaciente();
                        p.idPaciente = Convert.ToInt32(dr["IDPACIENTE"]);
                        p.Nombres = dr["NOMBRES"].ToString();
                        p.Apellidos = dr["APELLIDOS"].ToString();
                        p.Edad = dr["EDAD"].ToString();
                    c.Paciente = p;          
                    lista.Add(c);
                }
            }
            catch (Exception ex) { throw ex; }
            return lista;
        }

        public Int32 ListarCantidadConsultas()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int success = -1;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarCantidadConsultas", cn);
                cn.Open();
                success = (int)(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return success;
        }

        public entConsultaMedica ObtenerHistorialClinico(Int16 idHistorial)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            entConsultaMedica c = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spHistorialClinicoxId", cn);
                cmd.Parameters.AddWithValue("@prmintIdHistorialClinico", idHistorial);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c = new entConsultaMedica();
                    c.Fecha = Convert.ToDateTime(dr["FECHA"].ToString());
                    c.Sintomas = dr["SINTOMAS"].ToString();
                    c.Examenes = dr["EXAMENES"].ToString();
                    c.Tratamiento = dr["TRATAMIENTO"].ToString();
                    c.Observaciones = dr["OBSERVACIONES"].ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return c;
        }
        #endregion metodos
    }
  
}
