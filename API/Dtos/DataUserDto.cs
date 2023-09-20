using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DataUserDto
{
    public string Mensaje { get; set; }
        public bool EstadoAutenticado { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public List<string> UserRoles { get; set; }
        public string UserToken { get; set; }
        [JsonIgnore]
        public string RefreshToken {get; set;}
        public DateTime RefreshTokenExpiry {get; set;}

}
}