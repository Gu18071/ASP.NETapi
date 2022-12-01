using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Validations;

namespace ProjetoHackathon.Domain.Commands;

public class ClienteAlterarCommand : Notificavel, ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public int IdClinica { get; set; }

    public ClienteAlterarCommand() { }

    public ClienteAlterarCommand(int id, string nome, int idClinica, string cpf, string email, string telefone, string endereco)
    {
        Id = id;
        Nome = nome;
        IdClinica = idClinica;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");

        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome deve ser informado");

        if (IdClinica <= 0)
            AdicionarNotificacao("Código da clinica informado inválido");

        if (string.IsNullOrEmpty(Cpf))
            AdicionarNotificacao("O CPF deve ser informado");

        if (string.IsNullOrEmpty(Email))
            AdicionarNotificacao("O email deve ser informado");

        if (string.IsNullOrEmpty(Telefone))
            AdicionarNotificacao("O Telefone deve ser informado");

        if (string.IsNullOrEmpty(Endereco))
            AdicionarNotificacao("O endereço deve ser informado");
    }
}