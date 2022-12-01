using ProjetoHackathon.Domain.Commands.Interfaces;

namespace ProjetoHackathon.Domain.Handlers.Interfaces;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}