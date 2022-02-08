
using System;

namespace Strab.Domain.DTOs.Users
{
    public class CreateUserDTO
    {
        public CreateUserDTO()
        {

        }
        public CreateUserDTO(string name, string document, DateTime dateBirth, string gender, string description, string phone, string photo, string backImage, string email, string password, string facebookToken, string googleToken, int roleId, string platform, string platformVersion, string userType)
        {
            Name = name;
            Document = document;
            DateBirth = dateBirth;
            Gender = gender;
            Description = description;
            Phone = phone;
            Photo = photo;
            BackImage = backImage;
            Email = email;
            Password = password;
            FacebookToken = facebookToken;
            GoogleToken = googleToken;
            RoleId = roleId;
            Platform = platform;
            PlatformVersion = platformVersion;
            UserType = userType;
        }

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