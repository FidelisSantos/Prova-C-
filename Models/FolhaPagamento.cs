
namespace Api.Models
{
  public class FolhaPagamento
  {
    public int FolhaPagamentoId { get; set; }
    public double ValorHora { get; set; }
    public int QuantidadeHorar { get; set; }
    public double SalarioBruto { get; set; }
    public double ImpostoDeRenda { get; set; }
    public double ImpostoInss { get; set; }
    public double ImpostoFgts { get; set; }
    public double SalarioLiquido { get; set; }
    public UserModel Usuario { get; set; }
    public int UserModelID { get; set; }
    public int MesPagamento { get; set; }
    public int AnoPagamento { get; set; }

  }
}