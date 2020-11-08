using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifinAPI.Models;
using LifinAPI.Dtos.BdeDtos;
using Microsoft.EntityFrameworkCore;

namespace LifinAPI.Data.BdeRepoFolder
{
    public class BdeRepo : IBdeRepo
    {
        private readonly LifinContext context;
        public BdeRepo(LifinContext _context)
        {
            context = _context;
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
        public void CreateBde(Bde bde)
        {
            if(bde == null)
            {
                throw new ArgumentNullException(nameof(bde));
            }
            context.Bdes.Add(bde);
        }

        public void DeleteBde(Bde bde)
        {
            if(bde == null)
            {
                throw new ArgumentNullException(nameof(bde));
            }
            context.Bdes.Remove(bde);
        }
        public IEnumerable<Bde> GetAllBde(string filterValue)
        {
            IEnumerable<Bde> bdeList;
            if(filterValue == null)
            {
                bdeList = context.Bdes;
            }
            else
            {
                bdeList = context.Bdes.Where(bde => bde.Name.Contains(filterValue) || bde.School.Contains(filterValue));
            }
            return bdeList.ToList();
        }

        public Bde GetBde(int id)
        {
            var bde = context.Bdes.FirstOrDefault(b => b.Id == id);
            return bde;
        }

        public IEnumerable<Event> GetBdeEvents(int bdeId)
        {
            return context.Events.Where(e => e.BdeId == bdeId).ToList();
        }

        public void AddMember(Member member)
        {
            if(member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }
            context.Members.Add(member);
        }

        public IEnumerable<Member> GetBdeMembers(int bdeId)
        {
            return context.Members.Where(m => m.BdeId == bdeId).Include(m => m.User).ToList();
        }
    }
}
