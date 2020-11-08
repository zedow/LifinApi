using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifinAPI.Dtos.HypeDtos;
using LifinAPI.Models;

namespace LifinAPI.Profiles
{
    public class HypeProfile : Profile
    {
        public HypeProfile()
        {
            CreateMap<HypeReadDto, Hype>();
            CreateMap<Hype, HypeReadDto>();
            CreateMap<HypeCreateDto,Hype> ();
        }
    }
}
