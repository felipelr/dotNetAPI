using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Strab.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        public User()
        {
        }
        public User(long id, string email, string password, string facebookToken, string googleToken, bool active, DateTime created, DateTime modified, Role role, string platform, string platformVersion)
        {
            Id = id;
            Email = email;
            Password = password;
            FacebookToken = facebookToken;
            GoogleToken = googleToken;
            Active = active;
            Created = created;
            Modified = modified;
            Role = role;
            Platform = platform;
            PlatformVersion = platformVersion;

            if (role != null)
                RoleId = role.Id;
        }

        public void ClearPassword()
        {
            Password = "";
        }

        public void SetHashedPassword(string passwordHashed)
        {
            Password = passwordHashed;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(255, ErrorMessage = "Este campo deve conter entre 3 e 255 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 255 caracteres")]
        public string Email { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(255, ErrorMessage = "Este campo deve conter entre 3 e 255 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 255 caracteres")]
        public string Password { get; private set; }

        [MaxLength(255, ErrorMessage = "Este campo deve conter no máximo 255 caracteres")]
        public string FacebookToken { get; private set; }

        [MaxLength(255, ErrorMessage = "Este campo deve conter no máximo 255 caracteres")]
        public string GoogleToken { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DefaultValue(true)]
        public bool Active { get; private set; }

        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Função inválida")]
        public int RoleId { get; private set; }
        public Role Role { get; private set; }

        public string Platform { get; private set; }
        public string PlatformVersion { get; private set; }
    }
}