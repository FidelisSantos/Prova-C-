
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
  public class UserModel
  {
    //Construtor
    public int UserModelId { get; set; }
    public string Name { get; set; }
    public long Cpf { get; set; }
    public DateTime Nascimento { get; set; }
    public DateTime CriadoEm { get; set; }
    public FolhaPagamento Folha { get; set; }
  }

}