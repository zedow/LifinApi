using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LifinAPI.Data.EventRepoFolder;
using AutoMapper;
using LifinAPI.Models;
using LifinAPI.Dtos.EventDtos;
using LifinAPI.Dtos.BdeDtos;
using LifinAPI.Data.BdeRepoFolder;

namespace LifinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEventRepo repo;

        public EventsController(IEventRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventReadDto>> GetEvents()
        {
            return Ok(mapper.Map<IEnumerable<EventReadDto>>(repo.GetEvents()));
        }

        [HttpGet("{id}")]
        public ActionResult GetEvent(int id)
        {
            var bde = repo.GetEvent(id);
            if(bde == null)
            {
                return NotFound();
            }
            return Ok(bde);
        }
    }
}