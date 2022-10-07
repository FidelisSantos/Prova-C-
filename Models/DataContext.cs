//dotnet ef migrations add Initial
using Microsoft.EntityFrameworkCore;

//Permite trazer as funcionalidades para usar banco 
namespace Api.Models
{
  public class DataContext : DbContext
  {
    //Classe que representa o banco de dados dentro da aplicação.
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    //base é como se fosse o super em java, seria dentro do contrutor super(options)
    /* protected override void OnModelCreating(ModelBuilder mb)
    {
      base.OnModelCreating(mb);

      mb.ApplyConfiguration(new UserModelMapping());
      mb.ApplyConfiguration(new LoginModelMapping());
    } */

    //Para criar o banco de dados sempre usar DbSet que sabe que precisa
    public DbSet<UserModel> UserModels { get; set; }
    public DbSet<FolhaPagamento> Folhas { get; set; }
    //Fazendo a migração -> dotnet ef  migrations add Initial
    //Fazendo update para subir alterações no banco -> dotnet ef database update
  }
}