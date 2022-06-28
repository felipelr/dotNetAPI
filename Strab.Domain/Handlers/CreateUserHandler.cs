using Flunt.Notifications;
using Strab.Domain.Commands;
using Strab.Domain.Commands.Interfaces;
using Strab.Domain.Commands.Users;
using Strab.Domain.Entities;
using Strab.Domain.Handlers.Interfaces;
using Strab.Domain.Repositories;

namespace Strab.Domain.Handlers
{
    public class CreateUserHandler : Notifiable<Notification>, IHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProfessionalRepository _professionalRepository;

        public CreateUserHandler(IUserRepository userRepository, IRoleRepository roleRepository, IClientRepository clientRepository, IProfessionalRepository professionalRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _clientRepository = clientRepository;
            _professionalRepository = professionalRepository;
        }

        public async Task<ICommandResult> Handle(CreateUserCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(
                    false,
                    "Não foi possível criar o usuário.",
                    command.Notifications
                );
            }

            int roleId = command.UserType == "professional" ? 3 : 2;
            Role role = await _roleRepository.GetById(roleId);

            //criar usuario
            User user = new User(0,
                command.Email,
                command.Password,
                command.FacebookToken,
                command.GoogleToken,
                true,
                DateTime.Now,
                DateTime.Now,
                role,
                command.Platform,
                command.PlatformVersion
            );
            _userRepository.Create(user);

            //criar client
            Client client = new Client(
                0,
                command.Name,
                command.Document,
                command.Gender,
                command.Phone,
                command.Photo,
                true,
                command.DateBirth,
                0,
                DateTime.Now,
                DateTime.Now,
                user
            );
            _clientRepository.Create(client);

            if (command.UserType == "professional")
            {
                //criar professional se requisitado
                Professional professional = new Professional(
                    0,
                    command.Name,
                    command.Description,
                    command.Document,
                    command.Phone,
                    command.Photo,
                    command.BackImage,
                    true,
                    command.DateBirth,
                    0,
                    0,
                    DateTime.Now,
                    DateTime.Now,
                    user
                );

                _professionalRepository.Create(professional);
            }

            return new GenericCommandResult(
                true,
                "Usuário criado com sucesso!",
                user
            );
        }
    }
}