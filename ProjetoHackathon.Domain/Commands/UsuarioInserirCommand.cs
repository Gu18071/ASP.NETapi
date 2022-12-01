using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Validations;

namespace ProjetoHackathon.Domain.Commands;

public class UsuarioInserirCommand : Notificavel, ICommand
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Cnpj { get; set; }
    public string Senha { get; set; }

    public UsuarioInserirCommand() { }

    public UsuarioInserirCommand(string nome, string email, int cnpj, string senha)
    {
        Nome = nome;
        Email = email;
        Cnpj = cnpj;
        Senha = senha;
    }

    public void Validar()
    {
        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("Nome do usuario deve ser informado");
        if (string.IsNullOrEmpty(Email))
            AdicionarNotificacao("Email do usuario deve ser informado");
        if (Cnpj <= 0)
            AdicionarNotificacao("Cnpj informado inválido");
        if (string.IsNullOrEmpty(Senha))
            AdicionarNotificacao("Senha do usuario deve ser informada");
    }
}