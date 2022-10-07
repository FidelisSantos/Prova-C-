using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Request;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
  [Route("api/usuario")]
  [ApiController]
  //No C# : significa herança e implementação.
  public class UsuarioController : ControllerBase
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    //Pedindo contexto 
    public UsuarioController(DataContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    //Requisição via GET pro /api/usuario/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar() => _context.UserModels.Any() ? Ok(_context.UserModels.Include(u => u.Folha).ToList()) : NotFound("Nenhum usuário encontrado");

    //Método Post
    [HttpPost]
    [Route("cadastrar")]
    //Colocar como irá receber o parâmetro usando From... e da onde vai receber.
    public IActionResult Cadastrar([FromBody] UserRequest userRequest)
    {
      var user = _mapper.Map<UserModel>(userRequest);
      //Sintaxe para inserir no banco
      user.CriadoEm = DateTime.Now;
      _context.UserModels.Add(user);
      //Comando para salvar no banco
      _context.SaveChanges();
      //Created é o retorno correto do Post, primeiro parâmetro url segundo valor um objeto
      //users.Add(user);
      return Created("", user);

      //Informando que caso de erro irá dar conflito
      //return Conflict();
    }

    [HttpPost]
    [Route("buscar/{Cpf}")]
    //Buscar usuário pelo nome
    public IActionResult Buscar([FromRoute] int Cpf)
    {
      //Comparação usando Lambda
      //FirstOrDefault pode também ser trabalhado no banco
      var user = _context.UserModels.Include(f => f.Folha).FirstOrDefault(f => f.Cpf.Equals(Cpf));
      return user != null ? Ok(user) : NotFound();
    }

    [HttpDelete]
    [Route("deletar/{Cpf}")]
    public IActionResult Deletar([FromRoute] int Cpf)
    {
      var user = _context.UserModels.FirstOrDefault(f => f.Cpf.Equals(Cpf));
      if (user != null)
      {
        _context.UserModels.Remove(user);
        _context.SaveChanges();
        return Ok("Deletado");
      }
      return NotFound();
    }

    [HttpPut]
    [Route("atulizar/{Cpf}")]
    public IActionResult Atualizar([FromRoute] string Cpf, [FromBody] UserRequest userRequest)
    {
      var userCadastrado = _mapper.Map<UserModel>(userRequest);
      var user = _context.UserModels.FirstOrDefault(f => f.Cpf.Equals(Cpf));
      if (userCadastrado != null)
      {
        user = userCadastrado;
        _context.SaveChanges();
        return Ok(user);
      }
      return BadRequest();
    }
  }
}