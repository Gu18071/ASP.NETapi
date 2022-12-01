using ProjetoHackathon.Domain.Commands;
using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Handlers.Interfaces;
using ProjetoHackathon.Domain.Repositories;

namespace ProjetoHackathon.Domain.Handlers;

public class ClienteHandler :
    IHandler<ClienteInserirCommand>,
    IHandler<ClienteAlterarCommand>,
    IHandler<ClienteExcluirCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    #region Inserir

    public ICommandResult Handle(ClienteInserirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao incluir", 
                                            command.Notificacoes);

        var cliente = new Cliente(command.Nome, command.Cpf, command.Email, command.Telefone, command.Endereco, command.IdClinica);

        _clienteRepository.Inserir(cliente);

        return new CommandResult(true, "Cliente inserido", cliente);
    }

    #endregion

    #region Alterar

    public ICommandResult Handle(ClienteAlterarCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao alterar",
                                                command.Notificacoes);

        var cliente = _clienteRepository.BuscarPorId(command.Id);

        if (cliente == null)
            return new CommandResult(false, "Cliente não encontrado",
                                                command.Notificacoes);

        cliente.Nome = command.Nome;
        cliente.Cpf = command.Cpf;
        cliente.Email = command.Email;
        cliente.Telefone = command.Telefone;
        cliente.Endereco = command.Endereco;
        cliente.ClinicaId = command.IdClinica;

        _clienteRepository.Alterar(cliente);

        return new CommandResult(true, "Cliente alterado", cliente);
    }

    #endregion

    #region Excluir

    public ICommandResult Handle(ClienteExcluirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao excluir",
                                            command.Notificacoes);

        var cliente = _clienteRepository.BuscarPorId(command.Id);

        if (cliente == null)
            return new CommandResult(false, "Cliente não encontrado",
                                            command.Notificacoes);

        _clienteRepository.Excluir(cliente);

        return new CommandResult(true, "Cliente excluído", cliente);
    }

    #endregion
}