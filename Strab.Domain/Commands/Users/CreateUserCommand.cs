using Strab.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;
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
            AddNotifications(new CreateUserDTOContract(CreateUserDTO));
        }
    }

    public class CreateUserDTOContract : Contract<CreateUserDTO>
    {
        public CreateUserDTOContract(CreateUserDTO dto)
        {
            DateTime minDateBirth = DateTime.Now.AddYears(-18);
            Requires()
                .IsEmail(dto.Email, "Email")
                .IsGreaterThan(dto.Password, 8, "Password")
                .IsGreaterThan(dto.RoleId, 0, "RoleId")
                .IsNotNullOrEmpty(dto.Name, "Name")
                .IsNotNullOrEmpty(dto.Document, "Document")
                .IsNotNullOrEmpty(dto.Phone, "Phone")
                .IsLowerOrEqualsThan(dto.DateBirth, minDateBirth, "DateBirth");
        }
    }
}