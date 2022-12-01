using ProjetoHackathon.Domain.Entities;

namespace ProjetoHackathon.Domain.Repositories;

public interface IClienteRepository
{
    void Inserir(Cliente cliente);
    void Alterar(Cliente cliente);
    void Excluir(Cliente cliente);
    IEnumerable<Cliente> BuscarTodos();
    IEnumerable<Cliente> BuscarPorClinica(int IdClinica);
    Cliente? BuscarPorId(int id);
}