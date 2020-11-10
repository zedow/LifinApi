using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Dtos.BdeDtos
{
    public class BdeListItemReadDto
    {
        public BdeReadDto Bde { get; set; }
        public bool isFollowed { get; set; }
    }
}
