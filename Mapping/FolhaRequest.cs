using Api.Models;
using AutoMapper;

namespace Api.Request
{
  public class FolhaRequest
  {
    public int QuantidadeHorar { get; set; }
    public double ValorHora { get; set; }
    public int MesPagamento { get; set; }
    public int AnoPagamento { get; set; }
  }
}