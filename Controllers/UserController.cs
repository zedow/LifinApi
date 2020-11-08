using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LifinAPI.Data.BdeRepoFolder;
using LifinAPI.Data.UserRepoFolder;
using AutoMapper;
using LifinAPI.Models;
using LifinAPI.Dtos.EventDtos;
using LifinAPI.Dtos.UserDtos;
using LifinAPI.Dtos.HypeDtos;
namespace LifinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepo repo;
        public UsersController(IUserRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }

        [HttpGet("{id}")]
        public ActionResult GetUser(string userId)
        {
            var userFromRepo = repo.GetUser(userId);
            if(userFromRepo == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserReadDto>(userFromRepo));
        }

        [HttpPost]
        public ActionResult AddUser(UserCreateDto user)
        {
            var userModel = mapper.Map<User>(user);
            repo.CreateUser(userModel);
            repo.SaveChanges();
            return Ok(mapper.Map<UserReadDto>(userModel));
        }

        [HttpGet("{userId}/events")]
        public ActionResult<IEnumerable<UserEvent>> GetEventsFromFollowedBde(string userId)
        {
            return Ok(mapper.Map<IEnumerable<UserEventReadDto>>(repo.GetFollowedBdeEvents(userId)));
        }

        [HttpPost("{userId}/events")]
        public ActionResult AddHypeToEvent(HypeCreateDto hype)
        {
            var hypeModel = mapper.Map<Hype>(hype);
            repo.AddHypeOnEvent(hypeModel);
            repo.SaveChanges();
            return Ok();
        }
    }
}
