using System.Collections.Generic;
using DTO;

namespace DAO
{
    public interface ITelefoneDAO
    {
        TelefoneDTO Consultar(int id);
        List<TelefoneDTO> ConsultarPorContato(int contatoId);
        void Criar(TelefoneDTO telefone);
        void Atualizar(TelefoneDTO telefoneDTO);
        void Excluir(int id);
    }
}