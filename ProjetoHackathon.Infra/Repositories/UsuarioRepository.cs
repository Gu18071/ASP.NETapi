using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Queries;
using ProjetoHackathon.Domain.Repositories;
using ProjetoHackathon.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjetoHackathon.Infra.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DataContext _context;

    public UsuarioRepository(DataContext context)
    {
        _context = context;
    }

    public void Inserir(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void Alterar(Usuario usuario)
    {
        _context.Entry(usuario).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Excluir(Usuario usuario)
    {
        _context.Remove(usuario);
        _context.SaveChanges();
    }

    public Usuario? BuscarPorId(int id)
    {
        return _context.Usuarios
            .Where(UsuarioQueries.BuscarPorId(id))
            .FirstOrDefault();
    }

    public IEnumerable<Usuario> BuscarTodos()
    {
        return _context.Usuarios
            .AsNoTracking()
            .OrderBy(x => x.Nome);
    }
}