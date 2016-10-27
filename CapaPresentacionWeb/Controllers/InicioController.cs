using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionWeb.Controllers
{
    public class InicioController : Controller
    {
        //
        // GET: /Inicio/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}
