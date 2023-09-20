using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string UserEmail { get; set;}
        public string UserPassword { get; set;}
        public ICollection<Rol> Rols { get; set; } = new HashSet<Rol>();
        public ICollection<UserRol> UsersRols { get; set;}
        public ICollection<RefreshToken> RefreshTokens { get; set;}
    }
}