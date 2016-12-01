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
        public ActionResult Nuevo(FormCollection frm)
        {
            try
            {
                entPaciente p = new entPaciente();
                p.Nombres = frm["txtNombres"].ToString();
                p.Apellidos = frm["txtApellidos"].ToString();
                p.Dni = frm["txtDni"].ToString();
                p.Direccion = frm["txtDireccion"].ToString();
                p.FechaNacimiento = Convert.ToDateTime(frm["txtFechaNacimiento"].ToString());
                p.Edad = frm["txtEdad"].ToString();
                p.Sexo = frm["cboGenero"].ToString();
                p.Correo = frm["txtCorreo"].ToString();
                p.Telefono = frm["txtTelefono"].ToString();
                p.Celular = frm["txtCelular"].ToString();

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
        public ActionResult Editar(FormCollection frm)
        {

            try
            {
                entPaciente p = new entPaciente();
                p.idPaciente = Convert.ToInt32(frm["txtIdPaciente"].ToString());
                p.Nombres = frm["txtNombres"].ToString();
                p.Apellidos = frm["txtApellidos"].ToString();
                p.Dni = frm["txtDni"].ToString();
                p.Direccion = frm["txtDireccion"].ToString();
                p.FechaNacimiento = Convert.ToDateTime(frm["txtFechaNacimiento"].ToString());
                p.Edad = frm["txtEdad"].ToString();
                p.Sexo = frm["cboGenero"].ToString();
                p.Correo = frm["txtCorreo"].ToString();
                p.Telefono = frm["txtTelefono"].ToString();
                p.Celular = frm["txtCelular"].ToString();

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

            public ActionResult ObtenerPacienteDNI(Int32 PacienteDNI) {
                try
                {
                    entPaciente p = negPaciente.Instancia.ObtenerPacientexDNI(PacienteDNI);
                    return Json(p, JsonRequestBehavior.AllowGet);
                    // return View(p);
                }
                catch (Exception ex)
                {

                    return RedirectToAction("Nuevo", "CitasMedicas", new { mensaje = "Error" });

                }
            }

            public ActionResult ObtenerPacienteID(Int16 PacienteID)
            {
                try
                {
                    entPaciente p = negPaciente.Instancia.ObtenerPaciente(PacienteID);
                    return Json(p, JsonRequestBehavior.AllowGet);
                    // return View(p);
                }
                catch (Exception ex)
                {

                    return RedirectToAction("Nuevo", "CitasMedicas", new { mensaje = "Error" });

                }
            }

            public ActionResult ObtenerCantidadPacientes()
            {
                Int32 p=0;
                try
                {
                    p = negPaciente.Instancia.ListarCantidadPacientes();
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
