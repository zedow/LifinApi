using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifinAPI.Models;

namespace LifinAPI.Data.BdeRepoFolder
{
    public interface IBdeRepo
    {
        bool SaveChanges();
        void CreateBde(Bde bde);
        void DeleteBde(Bde bde);
        IEnumerable<Bde> GetAllBde(string filterValue);
        Bde GetBde(int id);
        IEnumerable<Event> GetBdeEvents(int bdeId);
        void AddMember(Member member);
        IEnumerable<Member> GetBdeMembers(int bdeId);
        void AddFollower(Follower follower);
    }
}
