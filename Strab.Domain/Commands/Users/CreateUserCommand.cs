using Strab.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;
using Strab.Domain.Entities;
using Strab.Domain.DTOs.Users;

namespace Strab.Domain.Commands.Users
{
    public class CreateUserCommand : Notifiable<Notification>, ICommand
    {
        public CreateUserCommand()
        {

        }

        public CreateUserCommand(CreateUserDTO createUserDTO)
        {
            CreateUserDTO = createUserDTO;
        }

        public CreateUserDTO CreateUserDTO { get; set; }

        public void Validate()
        {
            DateTime minDateBirth = DateTime.Now.AddYears(-18);
            AddNotifications(
                new Contract<User>()
                .Requires()
                .IsEmail(CreateUserDTO.Email, "Email")
                .IsGreaterThan(CreateUserDTO.Password, 8, "Password")
                .IsGreaterThan(CreateUserDTO.RoleId, 0, "RoleId")
                .IsNotEmpty(CreateUserDTO.Name, "Name")
                .IsNotEmpty(CreateUserDTO.Document, "Document")
                .IsNotEmpty(CreateUserDTO.Phone, "Phone")
                .IsLowerOrEqualsThan(CreateUserDTO.DateBirth, minDateBirth, "DateBirth")
            );
        }
    }
}