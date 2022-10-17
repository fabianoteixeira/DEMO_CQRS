using AutoMapper;
using DemoCQRS.Application.Dtos.Request;
using DemoCQRS.Application.Dtos.Response;
using DemoCQRS.Domain.Entities;

namespace DemoCQRS.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Person, PersonResponseDto>();
            CreateMap<Person, UpdatePersonDto>();
        }
    }
}
