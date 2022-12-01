using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Validations;

namespace ProjetoHackathon.Domain.Commands;

public class ClienteInserirCommand : Notificavel, ICommand
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }

    public int IdClinica { get; set; }

    public ClienteInserirCommand() { }

    public ClienteInserirCommand(string nome, string cpf, string email, string telefone, string endereco, int idClinica)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        IdClinica = idClinica;
    }

    public void Validar()
    {
        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome deve ser informado");

        if (string.IsNullOrEmpty(Endereco))
            AdicionarNotificacao("O endereço deve ser informado");

        if (string.IsNullOrEmpty(Email))
            AdicionarNotificacao("O email deve ser informado");

        if (string.IsNullOrEmpty(Cpf))
            AdicionarNotificacao("O CPF deve ser informada");

        if (string.IsNullOrEmpty(Telefone))
            AdicionarNotificacao("O telefone deve ser informado");

        if (IdClinica <= 0)
            AdicionarNotificacao("A clinica deve ser informada");
    }
}