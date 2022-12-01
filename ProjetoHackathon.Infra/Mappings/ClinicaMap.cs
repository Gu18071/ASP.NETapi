using ProjetoHackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoHackathon.Infra.Mappings;

public class ClinicaMap : IEntityTypeConfiguration<Clinica>
{
    public void Configure(EntityTypeBuilder<Clinica> builder)
    {
        //Configura o nome da tabela
        builder.ToTable("Clinica");

        //configura a chave primaria
        builder.HasKey(x => x.Id);

        //configurando o autogenerate (Identity)
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        //configurando o campo Nome
        builder.Property(x => x.Nome)
            .HasColumnName("Nome") //opcional se for o mesmo nome do obj
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        //configurando o campo Email
        builder.Property(x => x.Email)
            .HasColumnName("Email") //opcional se for o mesmo nome do obj
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(40);

        //configurando o campo Senha
        builder.Property(x => x.Senha)
            .HasColumnName("Senha") //opcional se for o mesmo nome do obj
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(30);
    }
}