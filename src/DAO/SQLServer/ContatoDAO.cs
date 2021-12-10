using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using DTO;
using Dapper;

namespace DAO.SQLServer
{
    public class ContatoDAO : BaseDAO, IContatoDAO
    {

        public ContatoDAO(string connectionString) : base(connectionString)
        {
            
        }
        public List<ContatoDTO> Consultar()
        {
            using(var con = Connection)
            {
                con.Open();
                var result = con.Query<ContatoDTO>(
                    @"SELECT Id, Nome, Sobrenome, Email
                    FROM Contato;"
                ).ToList();
                return result;
            }
        }

        public ContatoDTO Consultar(int id)
        {
            using(var con = Connection)
            {
                con.Open();
                var result = con.Query<ContatoDTO>(
                    @"SELECT Id, Nome, Sobrenome, Email
                    FROM Contato
                    WHERE Id = @Id;", new { id }
                ).FirstOrDefault();
                return result;
            }
        }

        public void Criar(ContatoDTO contato)
        {
            using(var con = Connection)
            {
                con.Open();
                contato.Id = con.Execute(
                    @"INSERT INTO Contato
                    (Nome, Sobrenome, Email) VALUES
                    (@Nome, @Sobrenome, @Email);", contato
                );
            }
        }

        public void Atualizar(ContatoDTO contato)
        {
            using(var con = Connection)
            {
                con.Open();
                contato.Id = con.Execute(
                    @"UPDATE Contato SET
                    Nome = @Nome,
                    Sobrenome = @Sobrenome,
                    Email = @Email
                    WHERE Id = @Id;", contato
                );
            }
        }
        
        public void Excluir(int id)
        {
            using(var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"DELETE FROM Contato
                    WHERE Id = @Id;", new { id }
                );
            }
        }
    }
}