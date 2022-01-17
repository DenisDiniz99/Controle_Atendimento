using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(INotificador notificador) : base(notificador) { }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
