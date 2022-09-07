using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using api_citas.Model;

namespace api_citas.DAO
{
    public class CommonRepository : ICommonRepository
    {
        private readonly string connStr;

        public CommonRepository(string connStr)
        {
            this.connStr = connStr;
        }

        public IEnumerable<Horario> GetHorarios()
        {
            using (IDbConnection Conn = new SqlConnection(connStr))
            {
                return Conn.GetAll<Horario>();
            }
        }
    }
}

