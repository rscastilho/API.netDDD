using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain.Dtos
{
    public class UserDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        
    }
}