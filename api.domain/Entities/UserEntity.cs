using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain.Entities
{
    public class UserEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}