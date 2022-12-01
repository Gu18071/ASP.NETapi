using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Validations;

namespace ProjetoHackathon.Domain.Commands;

public class ClinicaExcluirCommand : Notificavel, ICommand
{
    public int Id { get; set; }

    public ClinicaExcluirCommand() { }

    public ClinicaExcluirCommand(int id)
    {
        Id = id;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");
    }
}