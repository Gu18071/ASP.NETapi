using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Queries;
using ProjetoHackathon.Domain.Repositories;
using ProjetoHackathon.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ProjetoHackathon.Infra.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly DataContext _context;

    public ClienteRepository(DataContext context)
    {
        _context = context;
    }

    public void Inserir(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
    }

    public void Alterar(Cliente cliente)
    {
        _context.Entry(cliente).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Excluir(Cliente cliente)
    {
        _context.Remove(cliente);
        _context.SaveChanges();
    }

    public IEnumerable<Cliente> BuscarPorClinica(int IdClinica)
    {
        return _context.Clientes
            .AsNoTracking()
            .Include(x => x.Clinica)
            .Where(ClienteQueries.BuscarPorClinica(IdClinica))
            .OrderBy(x => x.Nome);
    }

    public Cliente? BuscarPorId(int Id)
    {
        return _context.Clientes
            .Where(ClienteQueries.BuscarPorId(Id))
            .FirstOrDefault();
    }

    public IEnumerable<Cliente> BuscarTodos()
    {
        return _context.Clientes
            .AsNoTracking()
            .Include(x => x.Clinica)
            .OrderBy(x => x.Nome);
    }
}