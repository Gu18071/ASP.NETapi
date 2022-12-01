using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Validations;

namespace ProjetoHackathon.Domain.Commands;

public class ClienteExcluirCommand : Notificavel, ICommand
{
    public int Id { get; set; }

    public ClienteExcluirCommand() { }

    public ClienteExcluirCommand(int id)
    {
        Id = id;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("O Código deve ser informado");
    }
}