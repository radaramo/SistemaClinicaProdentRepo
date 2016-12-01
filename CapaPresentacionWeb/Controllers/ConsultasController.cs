using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacionWeb.Controllers
{
    public class ConsultasController : Controller
    {
        //
        // GET: /Consultas/

        public ActionResult Index(String mensaje)
        {
            ViewBag.mensaje = mensaje;
            if (Session["usuario"] == null) { return RedirectToAction("Login", "Intranet"); }
            entUsuario prop = (entUsuario)Session["usuario"];
            Int32 person = prop.Persona.idPersona;
            List<entCitaMedica> lista = negConsultaMedica.Instancia.ListarCitasMedicasMedicos(person);
            return View(lista);
        }
        [HttpGet]
        public ActionResult Nuevo(Int16 id)
        {
            try
            {
                entCitaMedica p = negCitaMedica.Instancia.ObtenerCitaMedica(id);
                return View(p);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "CitasMedicas", new { mensaje = "Error" });

            }
        }

        [HttpPost]
        public ActionResult Nuevo(FormCollection frm)
        {
            try
            {
                entConsultaMedica ec = new entConsultaMedica();
                    entPaciente p = new entPaciente();
                    p.idPaciente = Convert.ToInt32(frm["txtidPaciente"].ToString());
                    ec.Paciente = p;
                    entCitaMedica cm = new entCitaMedica();
                    cm.idCitaMedica = Convert.ToInt32(frm["txtidCitaMedica"].ToString());
                    ec.CitasMedicas = cm;
                    ec.Sintomas = frm["txtSintomas"].ToString();
                    ec.Examenes = frm["txtExamenes"].ToString();
                    ec.Tratamiento = frm["txtTratamiento"].ToString();
                    ec.Observaciones = frm["txtObservaciones"].ToString();

                Boolean inserto = negConsultaMedica.Instancia.InsertarConsultaHistorial(ec);
                if (inserto)
                {
                    return RedirectToAction("Index", "Consultas", new { mensaje = "Guardar" });
                }
                else
                {
                    return View(ec);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult ObtenerCantidadConsultas()
        {
            Int32 c = 0;
            try
            {
                c = negConsultaMedica.Instancia.ListarCantidadConsultas();
                return Json(c, JsonRequestBehavior.AllowGet);
                // return View(p);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Inicio", new { mensaje = "Error" });

            }
        }


    }
}
