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
    public class CommonController : Controller
    {
        private ICommonRepository commonRepository;

        public CommonController(ICommonRepository repository)
        {
            this.commonRepository = repository;
        }
        [HttpGet("horarios")]
        public async Task<IActionResult> GetHorarios()
        {
            var horarios = commonRepository.GetHorarios();
            return await Task.FromResult(new JsonResult(horarios));
        }

    }
}

