using System;
namespace api_citas.Model
{
    public class CitaInfo
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Horario { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public CitaInfo()
        {
        }
    }
}

