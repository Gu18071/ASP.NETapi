using ProjetoHackathon.Config;
using ProjetoHackathon.Domain.Commands;
using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Handlers;
using ProjetoHackathon.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProjetoHackathon.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _repository;
    private readonly ClienteHandler _handler;

    public ClienteController(IClienteRepository repository, ClienteHandler handler)
    {
        _repository = repository;
        _handler = handler;
    }
    [AllowAnonymous]
    [HttpGet]
    public IEnumerable<Cliente> BuscarTodos()
    {
        return _repository.BuscarTodos();
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public Cliente? BuscarPorId(int id)
    {
        return _repository.BuscarPorId(id);
    }

    [AllowAnonymous]
    [HttpPost]
    public CommandResult Inserir(ClienteInserirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }

    [AllowAnonymous]
    [HttpPut]
    public CommandResult Alterar(ClienteAlterarCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }

    [AllowAnonymous]
    [HttpDelete]
    public CommandResult Excluir(ClienteExcluirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }
}
