using ProjetoHackathon.Config;
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
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _repository;
    private readonly UsuarioHandler _handler;

    public UsuarioController(IUsuarioRepository repository, UsuarioHandler handler)
    {
        _repository = repository;
        _handler = handler;
    }
    [AllowAnonymous]
    [HttpGet]
    public IEnumerable<Usuario> BuscarTodos()
    {
        return _repository.BuscarTodos();
    }
   
    [HttpGet("{id}")]
    public Usuario? BuscarPorId(int id)
    {
        return _repository.BuscarPorId(id);
    }
   
    [HttpPost]
    public CommandResult Inserir(UsuarioInserirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }
  
    [HttpPut]
    public IActionResult CriptografarMD5(string senha)
    {
        return Ok(Criptografia.MD5Encrypt(senha));
    }

    [HttpDelete]
    public CommandResult Excluir(UsuarioExcluirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }
}
