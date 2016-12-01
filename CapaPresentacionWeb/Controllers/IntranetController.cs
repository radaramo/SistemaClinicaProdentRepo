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
            entUsuario prop = (entUsuario)Session["usuario"];
            Int32 person = prop.Persona.idPersona;
            ViewBag.PersonaP = person;
            return View();
        }

        public ActionResult Perfil(Int16 id)
        {
            try
            {              
                entUsuario u = negUsuario.Instancia.ObtenerUsuario(id);
                return View(u);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Principal", "Intranet");
            }
        }

        [HttpPost]
        public ActionResult Perfil(FormCollection frm)
        {
            try
            {
                entUsuario u = new entUsuario();

                entPersona p = new entPersona();
                p.idPersona = Convert.ToInt32(frm["txtidPersona"].ToString());
                p.Nombres = frm["txtNombres"].ToString();
                p.Apellidos = frm["txtApellidos"].ToString();
                p.Direccion = frm["txtDireccion"].ToString();
                p.Telefono = frm["txtTelefono"].ToString();
                u.Persona = p;
                u.idUsuario = Convert.ToInt32(frm["txtidUsuario"].ToString());
                u.UserName = frm["txtUserName"].ToString();
                u.Password = frm["txtPassword"].ToString();

                Boolean edito = negUsuario.Instancia.EditarPerfil(u);
                 if (edito)
                {

                    return RedirectToAction("Principal",
                        new { mensaje = "Intranet" });
                }
                else
                {
                    ViewBag.mensaje = "Error";
                    return View();
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Principal", "Intranet");
            }
        }

        public ActionResult CerrarSesion()
        {
                Session.Abandon();
                Session.Remove("usuario");
            return RedirectToAction("Login", "Intranet");
        }

    }
}
