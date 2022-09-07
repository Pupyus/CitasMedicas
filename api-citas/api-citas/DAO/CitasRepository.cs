using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using api_citas.Model;

namespace api_citas.DAO
{
    public class CitasRepository : ICitasRepository
    {
        private readonly string connStr;
        private IDbConnection Conn => new SqlConnection(connStr);

        public CitasRepository(string connStr)
        {
            this.connStr = connStr;
        }

        public Cita Get(int id)
        {
            using (IDbConnection Conn = new SqlConnection(connStr))
            {
                return Conn.Get<Cita>(id);
            }
        }

        public IEnumerable<CitaInfo> GetAll(int idMedico, DateTime fecha)
        {
            using (IDbConnection Conn = new SqlConnection(connStr))
            {
                string sql = "SELECT " +
                    "C.Id, " +
                    "H.Nombre [Horario], " +
                    "C.Fecha, " +
                    "C.IdPaciente, " +
                    "C.IdMedico, " +
                    "CONCAT(M.Nombre, ' ', M.Paterno, ' ', M.Materno) [Medico], " +
                    "CONCAT(P.Nombre, ' ', P.Paterno, ' ', P.Materno) [Paciente] " +
                    "FROM dbo.Cita C " +
                    "INNER JOIN dbo.Horario H ON H.Id = C.IdHorario " +
                    "INNER JOIN dbo.Persona M ON M.Id = C.IdMedico " +
                    "INNER JOIN dbo.Persona P ON P.Id = C.IdPaciente " +
                    "WHERE C.IdMedico = @IdMedico AND C.Fecha = @Fecha";
                return Conn.Query<CitaInfo>(sql, new
                {
                    IdMedico = idMedico,
                    Fecha = fecha
                });
            }
        }

        public void Save(Cita data)
        {
            using (IDbConnection Conn = new SqlConnection(connStr))
            {
                Conn.Insert<Cita>(data);
            }
        }

        public IEnumerable<Cita> Search(int idMedico, int idHorario, DateTime fecha)
        {
            using (IDbConnection Conn = new SqlConnection(connStr))
            {
                string sql = "SELECT " +
                    "C.Id, " +
                    "C.IdHorario, " +
                    "C.Fecha, " +
                    "C.IdPaciente, " +
                    "C.IdMedico " +
                    "FROM dbo.Cita C " +
                    "WHERE C.IdMedico = @IdMedico AND C.IdHorario = @IdHorario AND C.Fecha = @Fecha";
                return Conn.Query<Cita>(sql, new
                {
                    IdMedico = idMedico,
                    IdHorario = idHorario,
                    Fecha = fecha
                });
            }
        }
    }
}

