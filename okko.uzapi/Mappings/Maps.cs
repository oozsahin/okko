using AutoMapper;
using okko.uzapi.DTOs;
using okko.uzapi.Migrations;

namespace okko.uzapi.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Persons, PersonsDTO>().ReverseMap();
            CreateMap<Persons, PersonsCreateDTO>().ReverseMap();
        }   
    }
}
