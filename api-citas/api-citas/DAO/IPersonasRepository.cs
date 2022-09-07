using System;
using System.Collections.Generic;

namespace api_citas.DAO
{
    public interface IPersonasRepository
    {
        IEnumerable<Model.Persona> GetAllDoctores();
        Model.Persona GetPersona(int id);
        Model.Persona GetByMail(string mail);
        void Save(Model.Persona data);

    }
}

