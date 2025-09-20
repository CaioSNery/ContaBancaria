using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using ContaBancaria.Entities;
using ContaBancaria.Shared.Dtos;

namespace ContaBancaria.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteCreateDTO>().ReverseMap();
            CreateMap<Cliente, ClienteUpdateDTO>().ReverseMap();
            CreateMap<Conta, ContaUpdateDTO>().ReverseMap();
        }
    }
}