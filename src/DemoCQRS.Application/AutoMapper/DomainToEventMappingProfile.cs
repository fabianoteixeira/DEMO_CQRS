using AutoMapper;
using DemoCQRS.Application.Events;
using DemoCQRS.Domain.Entities;

namespace DemoCQRS.Application.AutoMapper
{
    public class DomainToEventMappingProfile : Profile
    {
        public DomainToEventMappingProfile()
        {
            CreateMap<Person, CreatePersonEvent>().ReverseMap();
            CreateMap<Person, UpdatePersonEvent>().ReverseMap();

        }
    }
}
