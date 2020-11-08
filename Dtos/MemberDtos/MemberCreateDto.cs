using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Dtos.MemberDtos
{
    public class MemberCreateDto
    {
        public string UserId { get; set; }
        public int BdeId { get; set; }
        public string Role { get; set; }
    }
}
