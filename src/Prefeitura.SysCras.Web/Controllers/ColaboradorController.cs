using Microsoft.AspNetCore.Mvc;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Web.Controllers
{
    public class ColaboradorController :  BaseController
    {
        private readonly IColaboradorRepositorio _repositorio;
        
        public ColaboradorController(INotificador notificador) : base(notificador) 
        { 
            
        }

        [HttpGet]
        public IActionResult Detalhes()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Detalhes()
        {

        }
    }
}
