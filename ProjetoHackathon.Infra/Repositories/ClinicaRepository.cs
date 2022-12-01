using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Queries;
using ProjetoHackathon.Domain.Repositories;
using ProjetoHackathon.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ProjetoHackathon.Infra.Repositories;

public class ClinicaRepository : IClinicaRepository
{
    private readonly DataContext _context;

    public ClinicaRepository(DataContext context)
    {
        _context = context;
    }

    public void Inserir(Clinica clinica)
    {
        _context.Clinicas.Add(clinica);
        _context.SaveChanges();
    }

    public void Alterar(Clinica clinica)
    {
        _context.Entry(clinica).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Excluir(Clinica clinica)
    {
        _context.Remove(clinica);
        _context.SaveChanges();
    }

    public Clinica? BuscarPorId(int id)
    {
        return _context.Clinicas
            .Where(ClinicaQueries.BuscarPorId(id))
            .FirstOrDefault();
    }

    public IEnumerable<Clinica> BuscarTodos()
    {
        return _context.Clinicas
            .AsNoTracking()
            .Include(x => x.Clientes)
            .OrderBy(x => x.Nome);
    }
}