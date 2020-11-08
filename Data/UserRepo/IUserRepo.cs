using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifinAPI.Models;

namespace LifinAPI.Data.UserRepoFolder
{
    public interface IUserRepo
    {
        bool SaveChanges();
        void CreateUser(User user);
        void DeleteUser(User user);
        User GetUser(string id);
        IEnumerable<UserEvent> GetFollowedBdeEvents(string userId);
        void AddHypeOnEvent(Hype hype);

        void RemoveHypeOnEvent(Hype hype);
    }
}
