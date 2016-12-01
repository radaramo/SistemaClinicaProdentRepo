using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacionWeb.Controllers
{
    public class CitasMedicasController : Controller
    {
        //
        // GET: /CitasMedicas/
        public ActionResult Index(String mensaje)
        {
            ViewBag.mensaje = mensaje;
            if (Session["usuario"] == null) { return RedirectToAction("Login", "Intranet"); }
            List<entCitaMedica> lista = negCitaMedica.Instancia.ListarCitasMedicas();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(FormCollection frm)
        {
            try
            {
                entCitaMedica ec = new entCitaMedica();
                    entPaciente p = new entPaciente();
                    p.idPaciente = Convert.ToInt32(frm["txtidPaciente"].ToString());
                ec.Paciente = p;
                    entMedico m = new entMedico();
                    m.idMedico = Convert.ToInt32(frm["cboMedicos"].ToString());
                ec.Medico = m;
                ec.Descripcion = frm["txtDescripcion"].ToString();
                ec.Fecha = Convert.ToDateTime(frm["txtFechaCitaMedica"].ToString());
                ec.Hora = frm["txtHora"].ToString();
                ec.TipoConsulta = Convert.ToInt32(frm["cboTipoConsulta"].ToString());
                Boolean inserto = negCitaMedica.Instancia.InsertarCitaMedica(ec);
                if (inserto)
                {
                    return RedirectToAction("Index", "CitasMedicas", new { mensaje = "Guardar" });
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

        public ActionResult Editar(Int16 id)
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
        public ActionResult Editar(FormCollection frm)
        {

            try
            {
                entCitaMedica ec = new entCitaMedica();
                ec.idCitaMedica = Convert.ToInt32(frm["txtIdCitaMedica"].ToString());
                entPaciente p = new entPaciente();
                p.idPaciente = Convert.ToInt32(frm["txtIdPaciente"].ToString());
                ec.Paciente = p;
                entMedico m = new entMedico();
                m.idMedico = Convert.ToInt32(frm["cboMedicos"].ToString());
                ec.Medico = m;
                ec.Descripcion = frm["txtDescripcion"].ToString();
                ec.Fecha = Convert.ToDateTime(frm["txtFechaCitaMedica"].ToString());
                ec.Hora = frm["txtHora"].ToString();
                ec.TipoConsulta = Convert.ToInt32(frm["cboTipoConsulta"].ToString());
                Boolean edito = negCitaMedica.Instancia.InsertarCitaMedica(ec);
                if (edito)
                {

                    return RedirectToAction("Index", "CitasMedicas",
                        new { mensaje = "Editar" });
                }
                else
                {
                    ViewBag.mensaje = "Error";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "CitasMedicas", new { mensaje = "Error" });

            }
        }

        public ActionResult Eliminar(Int16 id)
        {
            try
            {
                Boolean elimino = negCitaMedica.Instancia.EiminarCitaMedica(id);
                if (elimino)
                {
                    return RedirectToAction("Index",
                   new { mensaje = "Eliminar" });
                }
                else
                {
                    ViewBag.mensaje = "Error";
                    return View();
                }
            }
            catch (Exception e)
            {

                return RedirectToAction("Index", "Paciente", new { mensaje = "Error" });
            }
        }

        public ActionResult ObtenerCantidadCitas()
        {
            Int32 p = 0;
            try
            {
                p = negCitaMedica.Instancia.ListarCantidadCitas();
                return Json(p, JsonRequestBehavior.AllowGet);
                // return View(p);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Inicio", new { mensaje = "Error" });

            }
        }

    }
}
