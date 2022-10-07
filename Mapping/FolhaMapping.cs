using Api.Models;
using AutoMapper;

namespace Api.Request
{
  class FolhaMapping : Profile
  {
    public FolhaMapping()
    {
      CreateMap<FolhaRequest, FolhaPagamento>()
          .ReverseMap();

      CreateMap<UserModel, UserRequest>()
          .ReverseMap();
    }
  }
}