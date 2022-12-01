using ProjetoHackathon.Domain.Entities;

namespace ProjetoHackathon.Domain.Repositories;

public interface IUsuarioRepository
{
    void Inserir(Usuario usuario);
    void Alterar(Usuario usuario);
    void Excluir(Usuario usuario);
    IEnumerable<Usuario> BuscarTodos();
    Usuario? BuscarPorId(int id);
}