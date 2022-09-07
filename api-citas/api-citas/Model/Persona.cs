using System;
namespace api_citas.Model
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Mail { get; set; }
        public bool EsMedico { get; set; }
        public Persona()
        {
        }
    }
}

