using TemplateDDD.Domain.Entities;
using TemplateDDD.Domain.Views;
using AutoMapper;

namespace TemplateDDD.Application.DI
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<UserEntity, UserView>().ReverseMap();
		}
	}
}

