using ProjetoHackathon.Domain.Commands;
using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Handlers.Interfaces;
using ProjetoHackathon.Domain.Repositories;

namespace ProjetoHackathon.Domain.Handlers;

public class UsuarioHandler :
    IHandler<UsuarioInserirCommand>,
    IHandler<UsuarioAlterarCommand>,
    IHandler<UsuarioExcluirCommand>
{
    private readonly IUsuarioRepository _repository;

    public UsuarioHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    #region Inserir

    public ICommandResult Handle(UsuarioInserirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao inserir",
                                                command.Notificacoes);

        //criando a clinica apartir dos dados do command
        var usuario = new Usuario(command.Nome, command.Email, command.Cnpj, command.Senha);
        
        //inserindo no bando de dados
        _repository.Inserir(usuario);

        return new CommandResult(true, "Usuario inserido", usuario);
    }

    #endregion

    #region Alterar

    public ICommandResult Handle(UsuarioAlterarCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao alterar",
                                                command.Notificacoes);

        var usuario = _repository.BuscarPorId(command.Id);

        if (usuario == null)
            return new CommandResult(false, "Usuario não encontrado", command);

        usuario.Nome = command.Nome;
        usuario.Email = command.Email;
        usuario.Cnpj = command.Cnpj;
        usuario.Senha = command.Senha;

        _repository.Alterar(usuario);

        return new CommandResult(true, "Usuario alterado", usuario);
    }

    #endregion

    #region Excluir

    public ICommandResult Handle(UsuarioExcluirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao excluir",
                                                command.Notificacoes);

        var usuario = _repository.BuscarPorId(command.Id);

        if (usuario == null)
            return new CommandResult(false, "Usuario não encontrado", command);

        _repository.Excluir(usuario);
         
        return new CommandResult(true, "Usuario excluído", usuario);
    }

    #endregion
}