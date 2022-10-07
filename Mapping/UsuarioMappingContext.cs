using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Maping
{
  class UsuarioMappingContext : IEntityTypeConfiguration<FolhaPagamento>
  {
    public void Configure(EntityTypeBuilder<FolhaPagamento> builder)
    {

    }
  }
}