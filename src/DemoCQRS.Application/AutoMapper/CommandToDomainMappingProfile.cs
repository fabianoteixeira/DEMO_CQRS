using AutoMapper;
using DemoCQRS.Application.Commands;
using DemoCQRS.Domain.Entities;

namespace DemoCQRS.Application.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<CreatePersonCommand, Person>();
            CreateMap<UpdatePersonCommand, Person>();
        }
    }
}
