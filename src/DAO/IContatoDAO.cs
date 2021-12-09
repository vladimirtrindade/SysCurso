using System.Collections.Generic;
using DTO;

namespace DAO
{
    public interface IContatoDAO
    {
         List<ContatoDTO> Consultar();

         ContatoDTO Consultar(int id);

         void Criar(ContatoDTO contato);

        void Atualizar(ContatoDTO contato);

        void Excluir(int id);
    }
}