using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APIServer.Controllers
{
    public class FileClientController : Controller
    {
        [DisableRequestSizeLimit]
        public ActionResult Index()
        {
            ViewBag.Title = "Index Page";

            return View();
        }
    }
}