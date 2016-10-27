using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacionWeb.Controllers
{
    public class IntranetController : Controller
    {
        //
        // GET: /Intranet/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            try
            {
                String Usuario = frm["txtUsuario"];
                String Password = frm["txtPassword"];
                entUsuario u = negUsuario.Instancia.VerificarAcceso(Usuario, Password);
                //Crear atributo y guardar usuario en sesion
                Session["usuario"] = u;
                return RedirectToAction("Principal", "Intranet");
            }
            catch (ApplicationException ex)
            {
                ViewBag.mensaje = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("index", "Error", new { msj = ex.Message });
            }


        }

        public ActionResult Principal()
        {
            return View();
        }

    }
}
