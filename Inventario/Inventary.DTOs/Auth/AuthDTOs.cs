using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventary.DTOs.Auth
{
    public record UsertToRegisterDto(string Email,string Password,string Name, string Phone);
    public record UserToLoginDto(string Email, string Password);
    public record UserToListDto(int Id, string Email, string NAme, string Phone, string Token);
}