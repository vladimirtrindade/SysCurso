using System.Collections.Generic;
using System.Linq;
using Dapper;
using DTO;

namespace DAO.SQLServer
{
    public class TelefoneDAO : BaseDAO, ITelefoneDAO
    {
        public TelefoneDAO(string connectionString) : base(connectionString)
        {

        }

        public List<TelefoneDTO> ConsultarPorContato(int contatoId)
        {
            using (var con = Connection)
            {
                con.Open();
                var result = con.Query<TelefoneDTO>(
                    @"SELECT Id, ContatoId, Numero
                    FROM Telefone
                    WHERE ContatoId = @ContatoId;", new { contatoId }
                ).ToList();
                return result;
            }
        }

        public TelefoneDTO Consultar(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                var result = con.Query<TelefoneDTO>(
                    @"SELECT Id, ContatoId, Numero
                    FROM Telefone
                    WHERE Id = @Id;", new { id }
                ).FirstOrDefault();
                return result;
            }
        }

        public void Criar(TelefoneDTO telefoneDTO)
        {
            using(var con = Connection)
            {
                con.Open();
                telefoneDTO.Id = con.Execute(
                    @"INSERT INTO Telefone
                    (ContatoId, Numero) VALUES
                    (@ContatoId, @Numero);", telefoneDTO
                );
            }
        }

        public void Atualizar(TelefoneDTO telefoneDTO)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"UPDATE Telefone SET
                    Numero = @Numero
                    WHERE Id = @Id;", telefoneDTO
                );
            }
        }


        public void Excluir(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"DELETE FROM Telefone
                    WHERE Id = @Id;", new { id }
                );
            }
        }
    }
}