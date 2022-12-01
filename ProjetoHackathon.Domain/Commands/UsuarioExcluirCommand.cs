using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Validations;

namespace ProjetoHackathon.Domain.Commands;

public class UsuarioExcluirCommand : Notificavel, ICommand
{
    public int Id { get; set; }

    public UsuarioExcluirCommand() { }

    public UsuarioExcluirCommand(int id)
    {
        Id = id;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");
    }
}