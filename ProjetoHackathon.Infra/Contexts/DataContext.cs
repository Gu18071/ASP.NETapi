using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ProjetoHackathon.Infra.Contexts;

public class DataContext : DbContext
{
    public DataContext() { }

    public DataContext(DbContextOptions<DataContext> options)
                                                : base(options) { }

    public DbSet<Clinica> Clinicas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClinicaMap());
        modelBuilder.ApplyConfiguration(new ClienteMap());
        modelBuilder.ApplyConfiguration(new UsuarioMap());
    }
}