using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifinAPI.Models;

namespace LifinAPI.Data.EventRepoFolder
{
    public class EventRepo : IEventRepo
    {
         private readonly LifinContext context;
        public EventRepo(LifinContext _context)
        {
            context = _context;
        }

        public bool SaveChanges()
        {
            return (this.context.SaveChanges() > 0);
        }
        public void CreateEvent(Event myEvent)
        {
            if(myEvent == null)
            {
                throw new ArgumentNullException(nameof(myEvent));
            }
            context.Add(myEvent);
        }
        public void DeleteEvent(Event myEvent)
        {
            if(myEvent == null)
            {
                throw new ArgumentNullException(nameof(myEvent));
            }
            context.Events.Remove(myEvent);
        }
        public IEnumerable<Event> GetEvents()
        {
            return context.Events.ToList();
        }
        public Event GetEvent(int id)
        {
            return context.Events.FirstOrDefault(e => e.Id == id);
        }
    }
}
