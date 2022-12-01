using ProjetoHackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoHackathon.Infra.Mappings;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        //configurando o nome da tabela
        builder.ToTable("Cliente");

        //configurando a chave primaria
        builder.HasKey(x => x.Id);

        //configurando o autogenerate (Identity)
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        //configurando o campo Nome
        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR")
            .HasMaxLength(150)
            .IsRequired();

        //configurando o campo Cpf
        builder.Property(x => x.Cpf)
            .HasColumnName("Cpf")
            .HasColumnType("VARCHAR")
            .HasMaxLength(11)
            .IsRequired();

        //configurando o campo Email
        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(40)
            .IsRequired();

        //configurando o campo Telefone
        builder.Property(x => x.Telefone)
            .HasColumnName("Telefone")
            .HasColumnType("VARCHAR")
            .HasMaxLength(13)
            .IsRequired();

        //configurando o campo Endereco
        builder.Property(x => x.Endereco)
            .HasColumnName("Endereco")
            .HasColumnType("VARCHAR")
            .HasMaxLength(150)
            .IsRequired();

        //configurando os relacionamentos
        builder
            .HasOne(x => x.Clinica)
            .WithMany(x => x.Clientes)
            .HasConstraintName("FK_Cliente_Clinica");
    }
}