using System;
using System.Collections.Generic;

namespace api_citas.DAO
{
    public interface ICitasRepository
    {
        void Save(Model.Cita data);
        Model.Cita Get(int id);
        IEnumerable<Model.CitaInfo> GetAll(int idDoctor, DateTime fecha);
        IEnumerable<Model.Cita> Search(int idDoctor, int idHorario, DateTime fecha);
    }
}

