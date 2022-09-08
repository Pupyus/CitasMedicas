using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_citas.Controllers.Request;
using api_citas.DAO;
using api_citas.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_citas.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CitasController : Controller
  {
    private ICitasRepository citasRepository;
    private IPersonasRepository personasRepository;
    public CitasController(ICitasRepository citasRepository, IPersonasRepository personasRepository)
    {
      this.personasRepository = personasRepository;
      this.citasRepository = citasRepository;
    }

    [HttpGet("Agenda")]
    public async Task<IActionResult> Agenda([FromQuery] int idDoctor, [FromQuery] DateTime fecha)
    {
      var results = citasRepository.GetAll(idDoctor, fecha);

      return await Task.FromResult(new JsonResult(results));
    }

    [HttpGet("Disponibilidad")]
    public async Task<IActionResult> Disponiblidad([FromQuery] int idDoctor, [FromQuery] int idHorario, [FromQuery] DateTime fecha)
    {
      var found = citasRepository.Search(idDoctor, idHorario, fecha);

      return await Task.FromResult(new JsonResult(new
      {
        Disponible = !found.Any()
      }));
    }


    [HttpPost]
    public async Task<IActionResult> Agendar(CitaRequest request)
    {
      
        Persona paciente = new Persona()
        {
          Nombre = request.Name,
          Mail = request.Email,
          EsMedico = false
        };
        personasRepository.Save(paciente);

        paciente = personasRepository.GetByMail(request.Email);

        Cita cita = new Cita
        {
          IdMedico = request.IdDoctor,
          IdPaciente = paciente.Id,
          IdHorario = request.IdTime,
          Fecha = request.Date
        };
        citasRepository.Save(cita);

        return await Task.FromResult(new OkResult());

    }
  }
}

