using System;
namespace api_citas.Controllers.Request
{
  public class CitaRequest
  {
    public int IdDoctor { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Date { get; set; }
    public int IdTime { get; set; }

    public CitaRequest()
    {
    }
  }
}

