using ProjetoHackathon.Domain.Entities;
using System.Linq.Expressions;

namespace ProjetoHackathon.Domain.Queries;

public class ClinicaQueries
{
    public static Expression<Func<Clinica, bool>> BuscarPorId(int id)
    {
        return x => x.Id == id;
    }
}