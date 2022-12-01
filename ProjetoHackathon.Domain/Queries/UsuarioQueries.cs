using ProjetoHackathon.Domain.Entities;
using System.Linq.Expressions;

namespace ProjetoHackathon.Domain.Queries;

public class UsuarioQueries
{
    public static Expression<Func<Usuario, bool>> BuscarPorId(int id)
    {
        return x => x.Id == id;
    }
}