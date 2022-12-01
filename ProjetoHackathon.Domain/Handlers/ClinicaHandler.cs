using ProjetoHackathon.Domain.Commands;
using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Handlers.Interfaces;
using ProjetoHackathon.Domain.Repositories;

namespace ProjetoHackathon.Domain.Handlers;

public class ClinicaHandler :
    IHandler<ClinicaInserirCommand>,
    IHandler<ClinicaAlterarCommand>,
    IHandler<ClinicaExcluirCommand>
{
    private readonly IClinicaRepository _repository;

    public ClinicaHandler(IClinicaRepository repository)
    {
        _repository = repository;
    }

    #region Inserir

    public ICommandResult Handle(ClinicaInserirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao inserir",
                                                command.Notificacoes);

        //criando a clinica apartir dos dados do command
        var clinica = new Clinica(command.Nome, command.Email, command.Senha);
        
        //inserindo no bando de dados
        _repository.Inserir(clinica);

        return new CommandResult(true, "Clinica inserida", clinica);
    }

    #endregion

    #region Alterar

    public ICommandResult Handle(ClinicaAlterarCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao alterar",
                                                command.Notificacoes);

        var clinica = _repository.BuscarPorId(command.Id);

        if (clinica == null)
            return new CommandResult(false, "Clinica não encontrada", command);

        clinica.Nome = command.Nome;
        clinica.Email = command.Email;
        clinica.Senha = command.Senha;

        _repository.Alterar(clinica);

        return new CommandResult(true, "Clinica alterada", clinica);
    }

    #endregion

    #region Excluir

    public ICommandResult Handle(ClinicaExcluirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao excluir",
                                                command.Notificacoes);

        var clinica = _repository.BuscarPorId(command.Id);

        if (clinica == null)
            return new CommandResult(false, "Clinica não encontrada", command);

        _repository.Excluir(clinica);
         
        return new CommandResult(true, "Clinica excluída", clinica);
    }

    #endregion
}