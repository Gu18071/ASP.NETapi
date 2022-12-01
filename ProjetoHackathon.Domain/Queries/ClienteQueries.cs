using ProjetoHackathon.Domain.Entities;
using System.Linq.Expressions;

namespace ProjetoHackathon.Domain.Queries;

public class ClienteQueries
{
    public static Expression<Func<Cliente, bool>> BuscarPorId(int id)
    {
        return cliente => cliente.Id == id;
    }

    public static Expression<Func<Cliente, bool>> BuscarPorClinica(int idClinica)
    {
        return cliente => cliente.Clinica.Id == idClinica;
    }
}