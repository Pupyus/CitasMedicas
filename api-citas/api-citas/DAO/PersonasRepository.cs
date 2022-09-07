using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using api_citas.Model;

namespace api_citas.DAO
{
    public class PersonasRepository : IPersonasRepository
    {
        private readonly string connStr;

        public PersonasRepository(string connStr)
        {
            this.connStr = connStr;
        }

        public IEnumerable<Persona> GetAllDoctores()
        {
            using (IDbConnection Conn = new SqlConnection(connStr))
            {
                string sql = "SELECT " +
                    "p.Id, " +
                    "p.Nombre, " +
                    "p.Paterno, " +
                    "p.Materno, " +
                    "p.Mail, " +
                    "p.EsMedico " +
                    "FROM dbo.Persona p " +
                    "WHERE p.EsMedico = 1";
                var resultados = Conn.Query<Persona>(sql);

                return resultados;
            }
        }

        public Persona GetByMail(string mail)
        {
            using (IDbConnection Conn = new SqlConnection(connStr))
            {
                string sql = "SELECT " +
                    "P.Id, " +
                    "P.Nombre, " +
                    "p.Paterno, " +
                    "p.Materno, " +
                    "p.Mail, " +
                    "p.EsMedico " +
                    "FROM dbo.Persona p " +
                    "WHERE p.Mail = @param;";
                var resultado = Conn.QueryFirstOrDefault<Persona>(sql, new { Param = mail });

                return resultado;
            }
        }

        public Persona GetPersona(int id)
        {
            using (IDbConnection Conn = new SqlConnection(connStr))
            {
                string sql = "SELECT " +
                    "P.Id, " +
                    "P.Nombre, " +
                    "p.Paterno, " +
                    "p.Materno, " +
                    "p.Mail, " +
                    "p.EsMedico " +
                    "FROM dbo.Persona p " +
                    "WHERE p.Id = @param;";
                var resultado = Conn.QueryFirstOrDefault<Persona>(sql, new { Param = id });

                return resultado;
            }
        }

        public void Save(Persona data)
        {
            using (IDbConnection Conn = new SqlConnection(connStr))
            {
                string sql = "INSERT INTO dbo.Persona(Nombre, Paterno, Materno, Mail, EsMedico) " +
                    "VALUES " +
                    "(@Nombre, @Paterno, @Materno, @Mail, @EsMedico)";
                Conn.Execute(sql, new
                {
                    Nombre = data.Nombre,
                    Paterno = data.Paterno,
                    Materno = data.Materno,
                    Mail = data.Mail,
                    EsMedico = data.EsMedico
                });
            }
        }
    } 
}

