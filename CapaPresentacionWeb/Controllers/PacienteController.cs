using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacionWeb.Controllers
{
    public class PacienteController : Controller
    {
        //
        // GET: /Paciente/

        public ActionResult Index(String mensaje)
        {
            ViewBag.mensaje = mensaje;
            if (Session["usuario"] == null) { return RedirectToAction("Login", "Intranet"); }
            List<entPaciente> lista = negPaciente.Instancia.ListarPaciente();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(entPaciente p)
        {
            try
            {
                Boolean inserto = negPaciente.Instancia.InsertarPaciente(p);
                //Boolean inserto = true;
                if (inserto)
                {
                    return RedirectToAction("Index", "Paciente", new { mensaje = "Guardar" });
                }
                else
                {
                    return View(p);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Paciente", new { mensaje = "Error" });
            }
        }

        public ActionResult Editar(Int16 id)
        {
            try
            {
                entPaciente p = negPaciente.Instancia.ObtenerPaciente(id);
                return View(p);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Paciente", new { mensaje = "Error" });

            }
        }

        [HttpPost]
        public ActionResult Editar(entPaciente p)
        {
            try
            {

                Boolean edito = negPaciente.Instancia.InsertarPaciente(p);
                if (edito)
                {

                    return RedirectToAction("Index",
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
                return RedirectToAction("Index", "Paciente", new { mensaje = "Error" });

            }
        }
           
            public ActionResult Eliminar(Int16 id){
                
                try 
	            {	        
		            Boolean elimino = negPaciente.Instancia.EiminarPaciente(id);
                    if (elimino)
	                {
		                 return RedirectToAction("Index",
                        new { mensaje = "Eliminar" });
	                }
                    else{
                        ViewBag.mensaje = "Error";
                        return View();
                    }
	            }
	            catch (Exception e)
	            {
		
		            return RedirectToAction("Index", "Paciente", new { mensaje = "Error" });
	            }
          }
       

    }
}
