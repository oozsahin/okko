using AutoMapper;
using okko.uzapi.DTOs;
using okko.uzapi.Models;

namespace okko.uzapi.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Persons, PersonsDto>().ReverseMap();
            CreateMap<Persons, PersonsCreateDTO>().ReverseMap();
            CreateMap<Persons, PersonsUpdateDTO>().ReverseMap();
            CreateMap<Deposit, DepositDto>().ReverseMap();
        }   
    }
}
