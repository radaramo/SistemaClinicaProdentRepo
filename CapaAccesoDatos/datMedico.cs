using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class datMedico
    {
        #region singleton
        private static readonly datMedico _instancia = new datMedico();
        public static datMedico Instancia
        {
            get { return datMedico._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entMedico> ListarMedico()
        {
            SqlCommand cmd = null;
            List<entMedico> lista = new List<entMedico>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarMedicos", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entMedico m = new entMedico();
                    m.idMedico = Convert.ToInt32(dr["IDMEDICO"]);
                        entPersona p = new entPersona();
                        p.Nombres = dr["MEDICO"].ToString();
                        m.Persona = p;
                    lista.Add(m);
                }
            }
            catch (Exception ex) { throw ex; }
            return lista;
        }
        #endregion metodos
    }
}
