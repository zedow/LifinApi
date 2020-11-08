using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifinAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using LifinAPI.Dtos.EventDtos;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LifinAPI.Data.UserRepoFolder
{
    public class UserRepo : IUserRepo
    {
        private readonly LifinContext context;
        public UserRepo(LifinContext _context)
        {
            context = _context;
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            context.Users.Add(user);
        }
        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            context.Users.Remove(user);
        }
        public User GetUser(string id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }
        public void AddHypeOnEvent(Hype hype)
        {
            if(hype == null)
            {
                throw new ArgumentNullException(nameof(hype));
            }
            context.Hypes.Add(hype);
        }
        public IEnumerable<UserEvent> GetFollowedBdeEvents(string userId)
        {
            var model = (from f in context.Followers.Where(f => f.UserId == userId)
                         join bde in context.Bdes on f.BdeId equals bde.Id into bdeJoin

                         from bde in bdeJoin
                         join e in context.Events on bde.Id equals e.BdeId into eventJoin

                         from e in eventJoin.DefaultIfEmpty()
                         join h in context.Hypes on e.Id equals h.EventId into hypeJoin

                         from h in hypeJoin.DefaultIfEmpty()
                         select new UserEvent
                         {
                             Id = e.Id,
                             Name = e.Name,
                             Date = e.Date,
                             Description = e.Description,
                             BdeId = e.BdeId,
                             Bde = bde,
                             IsHyped = h == null ? false : true
                         }).Where(ue => ue.Date >= new DateTime()).OrderBy(ue => ue.Date).ToList();

            return model;
            /*

            return context.Followers.Where(f => f.UserId == userId)
                .Join(
                    context.Bdes,
                    follower => follower.BdeId,
                    bde => bde.Id,
                    (follower, bde) => new Bde { Id = bde.Id, Name = bde.Name, Description = bde.Description, School = bde.School }
                )
                .Join(
                    context.Events
                    .Where(myEvent => myEvent.Date > new DateTime())
                    .Join(context.Hypes, 
                        myEvent => myEvent.Id, 
                        hype => hype.EventId, 
                        (myEvent, hype) => new { myEvent.BdeId,myEvent.Date, myEvent.Name, myEvent.Id, myEvent.Description, IsHyped = true}
                    ),
                    previousJoinResult => previousJoinResult.Id,
                    myEvent => myEvent.BdeId,
                    (previousJoinResult, myEvent) => new UserEvent { Id = myEvent.Id, Name = myEvent.Name, Date = myEvent.Date, Description = myEvent.Description, BdeId = myEvent.BdeId, Bde = previousJoinResult, IsHyped = myEvent.IsHyped  }
                ).OrderBy(e => e.Date).ToList();
            */
        }
    }
}
