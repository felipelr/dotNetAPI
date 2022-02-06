
using System;

namespace Strab.Domain.DTOs.Users
{
    public class CreateUserDTO
    {

        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string BackImage { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FacebookToken { get; set; }
        public string GoogleToken { get; set; }
        public int RoleId { get; set; }
        public string Platform { get; set; }
        public string PlatformVersion { get; set; }
        public string UserType { get; set; }
    }
}