using AutoMapper;
using LifinAPI.Dtos.FollowerDtos;
using LifinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Profiles
{
    public class FollowerProfile : Profile
    {
        public FollowerProfile()
        {
            CreateMap<Follower, FollowerReadDto>();
            CreateMap<FollowerReadDto, Follower>();
            CreateMap<FollowerCreateDto, Follower>();
        }
    }
}
