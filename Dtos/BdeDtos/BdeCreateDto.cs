using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Dtos.BdeDtos
{
    public class BdeCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string School { get; set; }
        public string OwnerId { get; set; }
    }
}
