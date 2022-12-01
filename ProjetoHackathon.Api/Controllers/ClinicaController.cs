using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoHackathon.Domain.Commands;
using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Handlers;
using ProjetoHackathon.Domain.Repositories;

namespace ProjetoHackathon.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ClinicaController : ControllerBase
{
    private readonly IClinicaRepository _repository;

    public ClinicaController(IClinicaRepository repository)
    {
        _repository = repository;
    }

    [AllowAnonymous]
    [HttpGet]
    public IEnumerable<Clinica> BuscarTodos([FromServices] IClinicaRepository repository)
    {
        return repository.BuscarTodos();
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public Clinica? BuscarPorId(int id)
    {
        return _repository.BuscarPorId(id);
    }

    [AllowAnonymous]
    [HttpPost]
    public CommandResult Inserir(ClinicaInserirCommand command,
        [FromServices] ClinicaHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }

    [AllowAnonymous]
    [HttpPut]
    public CommandResult Alterar(ClinicaAlterarCommand command,
        [FromServices] ClinicaHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }

    [AllowAnonymous]
    [HttpDelete]
    public CommandResult Excluir(ClinicaExcluirCommand command,
        [FromServices] ClinicaHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }
}
