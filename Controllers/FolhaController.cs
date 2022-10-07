using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Api.Request;
using AutoMapper;

namespace Api.Controllers
{
  [Route("Folha")]
  [ApiController]

  public class FolhaController : ControllerBase
  {
    private readonly DataContext _context;
    //Pedindo contexto 
    private readonly IMapper _mapper;
    public FolhaController(DataContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar() => _context.Folhas.Any() ? Ok(_context.Folhas.Include(u => u.Usuario).ToList()) : NotFound("Nenhuma Folha encontrada");

    [HttpPost]
    [Route("{Cpf}")]
    public IActionResult Cadastrar([FromRoute] long Cpf, [FromBody] FolhaRequest resquest)
    {
      var user = _context.UserModels.FirstOrDefault(u => u.Cpf == Cpf);
      if (user != null)
      {
        var folha = _mapper.Map<FolhaPagamento>(resquest);
        folha.SalarioBruto = folha.ValorHora * folha.QuantidadeHorar;
        if (folha.SalarioBruto >= 1903.99 && folha.SalarioBruto <= 2826.65)
        {
          folha.ImpostoDeRenda = folha.SalarioBruto * 0.075;
        }
        if (folha.SalarioBruto >= 2826.66 && folha.SalarioBruto <= 3751.05)
        {
          folha.ImpostoDeRenda = folha.SalarioBruto * 0.15;
        }
        if (folha.SalarioBruto >= 3751.06 && folha.SalarioBruto <= 4664.68)
        {
          folha.ImpostoDeRenda = folha.SalarioBruto * 0.225;
        }
        if (folha.SalarioBruto >= 4664.68)
        {
          folha.ImpostoDeRenda = folha.SalarioBruto * 0.27;
        }
        if (folha.SalarioBruto < 1903.99)
        {
          folha.ImpostoDeRenda = folha.SalarioBruto * 0;
        }
        if (folha.SalarioBruto <= 1693.72)
        {
          folha.ImpostoInss = folha.SalarioBruto * 0.08;
        }
        else if (folha.SalarioBruto >= 1693.73 && folha.SalarioBruto <= 2822.90)
        {
          folha.ImpostoInss = folha.SalarioBruto * 0.09;
        }
        else if (folha.SalarioBruto >= 2822.91 && folha.SalarioBruto <= 5645.80)
        {
          folha.ImpostoInss = folha.SalarioBruto * 0.11;
        }
        if (folha.SalarioBruto >= 5645.80)
        {
          folha.ImpostoInss = folha.SalarioBruto - 621.03;
        }
        folha.ImpostoFgts = folha.SalarioBruto * 0.08;
        folha.SalarioLiquido = folha.SalarioBruto - folha.ImpostoDeRenda - folha.ImpostoInss;
        folha.Usuario = user;
        folha.UserModelID = user.UserModelId;
        user.Folha = folha;
        _context.SaveChanges();
        return Created("", folha);
      }
      return BadRequest();
    }
    [HttpGet]
    [Route("{MesPagamento}/{AnoPagamento}")]
    public IActionResult listar([FromRoute] int MesPagamento, [FromRoute] int AnoPagamento)
    {
      return Ok(_context.Folhas.Include(u => u.Usuario).FirstOrDefault(f => f.AnoPagamento == AnoPagamento && f.MesPagamento == MesPagamento));
    }
    [HttpGet]
    [Route("{Cpf}/{MesPagamento}/{AnoPagamento}")]
    public IActionResult buscar([FromRoute] long Cpf, [FromRoute] int MesPagamento, [FromRoute] int AnoPagamento)
    {
      return Ok(_context.Folhas.Include(u => u.Usuario).FirstOrDefault(f => f.Usuario.Cpf == Cpf && f.AnoPagamento == AnoPagamento && f.MesPagamento == MesPagamento));
    }
  }
}