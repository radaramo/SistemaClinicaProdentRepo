using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacionWeb.Controllers
{
    public class HistorialController : Controller
    {
        //
        // GET: /Historial/

        public ActionResult Index()
        {
            if (Session["usuario"] == null) { return RedirectToAction("Login", "Intranet"); }
            List<entPaciente> lista = negPaciente.Instancia.ListarPaciente();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Historial(Int16 id)
        {
            ViewBag.PacienteID = id;
            List<entConsultaMedica> listah = negConsultaMedica.Instancia.ListarHistorialClinicoPaciente(id);
            return View(listah);
        }

        public ActionResult Mostrar(Int16 id)
        {
            try
            {
                entConsultaMedica p = negConsultaMedica.Instancia.ObtenerHistorialClinico(id);
                return View(p);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Paciente", new { mensaje = "Error" });

            }
        }

    }
}
