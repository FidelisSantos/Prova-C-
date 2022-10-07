namespace Api.Request
{
  public class UserRequest
  {
    public string Name { get; set; }
    public long Cpf { get; set; }
    public DateTime Nascimento { get; set; }
  }
}