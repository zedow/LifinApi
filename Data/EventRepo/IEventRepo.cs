using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifinAPI.Models;

namespace LifinAPI.Data.EventRepoFolder
{
    public interface IEventRepo
    {
        void CreateEvent(Event myEvent);
        void DeleteEvent(Event myEvent);
        IEnumerable<Event> GetEvents();
        Event GetEvent(int id);
    }
}
