using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LifinAPI.Data.BdeRepoFolder;
using AutoMapper;
using LifinAPI.Models;
using LifinAPI.Dtos.EventDtos;
using LifinAPI.Dtos.BdeDtos;
using LifinAPI.Dtos.MemberDtos;
using LifinAPI.Dtos.FollowerDtos;

namespace LifinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BdesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBdeRepo repo;
        public BdesController(IBdeRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BdeReadDto>> GetBdeList(string filter)
        {
            var bdeList = repo.GetAllBde(filter);
            return Ok(mapper.Map<IEnumerable<BdeReadDto>>(bdeList));
        }

        [HttpGet("{id}")]
        public ActionResult GetBde(int id)
        {
            var bde = repo.GetBde(id);
            if(bde == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BdeReadDto>(bde));
        }

        [HttpGet("{bdeId}/events")]
        public ActionResult<IEnumerable<EventReadDto>> GetBdeEvents(int bdeId)
        {
            var events = repo.GetBdeEvents(bdeId);
            if(events == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<IEnumerable<EventReadDto>>(events));
        }

        [HttpPost]
        public ActionResult<BdeReadDto> CreateBde(BdeCreateDto bde)
        {
            var bdeModel = mapper.Map<Bde>(bde);
            repo.CreateBde(bdeModel);
            repo.AddMember(mapper.Map<Member>(new MemberCreateDto { UserId = bde.OwnerId, BdeId = bdeModel.Id, Role = "Owner" }));
            repo.SaveChanges();
            return (Ok(mapper.Map<BdeReadDto>(bdeModel)));
        }

        //Members
        [HttpGet("{bdeId}/members")]
        public ActionResult<IEnumerable<MemberReadDto>> GetBdeMembers(int bdeId)
        {
            var members = repo.GetBdeMembers(bdeId);
            return Ok(mapper.Map<IEnumerable<MemberReadDto>>(members));
        }

        [HttpPost("{bdeId}/members")]
        public ActionResult<MemberReadDto> AddBdeMember(int bdeId,MemberCreateDto newMember)
        {
            var member = mapper.Map<Member>(newMember);
            member.BdeId = bdeId;
            repo.AddMember(member);
            repo.SaveChanges();
            return NoContent();
        }

       [HttpPost("{id}/follow")]
        public ActionResult<Follower> FolloweBde(int id,FollowerCreateDto follower)
        {
            var newFollower = mapper.Map<Follower>(follower);
            newFollower.BdeId = id;
            repo.AddFollower(newFollower);
            repo.SaveChanges();
            return Ok(mapper.Map<FollowerReadDto>(newFollower));
        }

       
    }
}
