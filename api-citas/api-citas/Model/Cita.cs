using System;
using Dapper.Contrib.Extensions;

namespace api_citas.Model
{
    [Table("Cita")]
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        public int IdHorario { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public Cita()
        {
        }
    }
}

