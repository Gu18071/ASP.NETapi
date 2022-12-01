namespace ProjetoHackathon.Domain.Entities;

public class Cliente : Entity
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }

    public int ClinicaId { get; set; }
    public Clinica Clinica { get; set; }

    public Cliente(string nome, string cpf, string email, string telefone, string endereco, int idClinica)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        ClinicaId = idClinica;
    }

    public Cliente(int id, string nome, string cpf, string email, string telefone, string endereco, int idClinica)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        ClinicaId = idClinica;
    }

    public Cliente() { }
}