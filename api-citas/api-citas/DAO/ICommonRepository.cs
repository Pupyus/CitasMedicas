using System;
using System.Collections.Generic;

namespace api_citas.DAO
{
    public interface ICommonRepository
    {
        IEnumerable<Model.Horario> GetHorarios();
    }
}

