using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class RegisterDto
{
    [Required]
    public string UserEmail { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string UserPassword { get; set; }
}
}