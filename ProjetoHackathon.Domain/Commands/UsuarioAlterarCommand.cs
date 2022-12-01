using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Validations;

namespace ProjetoHackathon.Domain.Commands;

public class UsuarioAlterarCommand : Notificavel, ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Cnpj { get; set; }
    public string Senha { get; set; }

    public UsuarioAlterarCommand() { }

    public UsuarioAlterarCommand(int id, string nome, string email, int cnpj, string senha)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Cnpj = cnpj;
        Senha = senha;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");

        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome deve ser informado");

        if (string.IsNullOrEmpty(Email))
            AdicionarNotificacao("O email deve ser informado");

        if (Cnpj <= 0)
            AdicionarNotificacao("Cnpj informado inválido");

        if (string.IsNullOrEmpty(Senha))
            AdicionarNotificacao("A senha deve ser informada");
    }
}