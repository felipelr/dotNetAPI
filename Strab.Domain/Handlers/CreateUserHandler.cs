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

        public ICommandResult Handle(CreateUserCommand command)
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

            int roleId = command.CreateUserDTO.UserType == "professional" ? 3 : 2;
            Role role = _roleRepository.GetById(roleId);

            //criar usuario
            User user = new User(0,
                command.CreateUserDTO.Email,
                command.CreateUserDTO.Password,
                command.CreateUserDTO.FacebookToken,
                command.CreateUserDTO.GoogleToken,
                true,
                DateTime.Now,
                DateTime.Now,
                role,
                command.CreateUserDTO.Platform,
                command.CreateUserDTO.PlatformVersion
            );
            _userRepository.Create(user);

            //criar client
            Client client = new Client(
                0,
                command.CreateUserDTO.Name,
                command.CreateUserDTO.Document,
                command.CreateUserDTO.Gender,
                command.CreateUserDTO.Phone,
                command.CreateUserDTO.Photo,
                true,
                command.CreateUserDTO.DateBirth,
                0,
                DateTime.Now,
                DateTime.Now,
                user
            );
            _clientRepository.Create(client);

            if (command.CreateUserDTO.UserType == "professional")
            {
                //criar professional se requisitado
                Professional professional = new Professional(
                    0,
                    command.CreateUserDTO.Name,
                    command.CreateUserDTO.Description,
                    command.CreateUserDTO.Document,
                    command.CreateUserDTO.Phone,
                    command.CreateUserDTO.Photo,
                    command.CreateUserDTO.BackImage,
                    true,
                    command.CreateUserDTO.DateBirth,
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