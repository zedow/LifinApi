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
using Microsoft.Extensions.Logging;
using LifinAPI.Dtos.BdeDtos;

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

        [HttpPost("events")]
        public ActionResult AddHypeToEvent(HypeCreateDto hype)
        {
            var hypeModel = mapper.Map<Hype>(hype);
            repo.AddHypeOnEvent(hypeModel);
            repo.SaveChanges();
            return Ok(true);
        }

        [HttpDelete("{userId}/events/{eventId}")]
        public ActionResult RemoveHypeToEvent(string userId, int eventId)
        {
            var hypeModel = mapper.Map<Hype>(new HypeCreateDto { UserId = userId, EventId = eventId});
            repo.RemoveHypeOnEvent(hypeModel);
            repo.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}/bde")]
        public ActionResult<IEnumerable<BdeListItemReadDto>> GetBdeListForUser(string id, string filter)
        {
            var list = repo.GetBdeListForUser(id,filter);
            return Ok(mapper.Map<IEnumerable<BdeListItemReadDto>>(list));
        }
    }
}
