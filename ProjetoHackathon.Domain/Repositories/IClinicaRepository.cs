using ProjetoHackathon.Domain.Entities;

namespace ProjetoHackathon.Domain.Repositories;

public interface IClinicaRepository
{
    void Inserir(Clinica clinica);
    void Alterar(Clinica clinica);
    void Excluir(Clinica clinica);
    IEnumerable<Clinica> BuscarTodos();
    Clinica? BuscarPorId(int id);
}