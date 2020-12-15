using AutoMapper;
using LifinAPI.Dtos.EventDtos;
using LifinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventReadDto>();
            CreateMap<EventReadDto, Event>();
            CreateMap<UserEvent, UserEventReadDto>();
            CreateMap<EventCreateDto, Event>();
        }
    }
}
