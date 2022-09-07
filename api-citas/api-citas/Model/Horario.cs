using System;
using Dapper.Contrib.Extensions;

namespace api_citas.Model
{
    [Table("Horario")]
    public class Horario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Horario()
        {
        }
    }
}

