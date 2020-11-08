using AutoMapper;
using LifinAPI.Dtos.MemberDtos;
using LifinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberReadDto>();
            CreateMap<MemberReadDto, Member>();
        }
    }
}
