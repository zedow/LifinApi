using AutoMapper;
using LifinAPI.Models;
using LifinAPI.Dtos.BdeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Profiles
{
    public class BdeProfile : Profile
    {
        public BdeProfile()
        {
            CreateMap<Bde, BdeReadDto>();
            CreateMap<BdeReadDto, Bde>();
            CreateMap<BdeCreateDto, Bde>();
            CreateMap<Bde, BdeCreateDto> ();
        }
    }
}
