using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_citas.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_citas.Controllers
{
    [Route("api/[controller]")]
    public class PersonasController : Controller
    {
        private IPersonasRepository repository;
        public PersonasController(IPersonasRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/values
        [HttpGet("Doctores")]
        public async Task<IActionResult> GetDoctores()
        {
            var doctores = repository.GetAllDoctores();
            return await Task.FromResult(new JsonResult(doctores));
        }
    }
}

