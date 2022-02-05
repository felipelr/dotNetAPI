using Strab.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;
using Strab.Domain.Entities;

namespace Strab.Domain.Commands
{
    public class CreateUserCommand : Notifiable<Notification>, ICommand
    {
        public CreateUserCommand()
        {

        }
        public CreateUserCommand(string email, string password, string facebookToken, string googleToken, int roleId, string platform, string platformVersion)
        {
            Email = email;
            Password = password;
            FacebookToken = facebookToken;
            GoogleToken = googleToken;
            RoleId = roleId;
            Platform = platform;
            PlatformVersion = platformVersion;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FacebookToken { get; private set; }
        public string GoogleToken { get; private set; }
        public int RoleId { get; private set; }
        public string Platform { get; private set; }
        public string PlatformVersion { get; private set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<User>()
                .Requires()
                .IsEmail(Email, "Email")
                .IsGreaterThan(Password, 8, "Password")
                .IsGreaterThan(RoleId, 0, "RoleId")
            );
        }
    }
}