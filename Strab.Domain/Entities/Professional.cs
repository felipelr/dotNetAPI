using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Strab.Domain.Entities
{
    [Table("Professionals")]
    public class Professional
    {
        public Professional()
        {
        }

        public Professional(long id, string name, string description, string document, string phone, string photo, string backImage, bool active, DateTime dateBirth, int websocket, int fiveStarsRating, DateTime created, DateTime modified, User user)
        {
            Id = id;
            Name = name;
            Description = description;
            Document = document;
            Phone = phone;
            Photo = photo;
            BackImage = backImage;
            Active = active;
            DateBirth = dateBirth;
            Websocket = websocket;
            FiveStarsRating = fiveStarsRating;
            Created = created;
            Modified = modified;
            User = user;

            if (user != null)
                UserId = user.Id;
        }

        [Key]
        public long Id { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(255, ErrorMessage = "Este campo deve conter entre 1 e 255 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 255 caracteres")]
        public string Name { get; private set; }

        [MaxLength(255, ErrorMessage = "Este campo deve conter no máximo 255 caracteres")]
        public string Description { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 11 e 20 caracteres")]
        [MinLength(11, ErrorMessage = "Este campo deve conter entre 11 e 20 caracteres")]
        public string Document { get; private set; }

        [MaxLength(20, ErrorMessage = "Este campo deve conter no máximo 20 caracteres")]
        public string Phone { get; private set; }

        [MaxLength(255, ErrorMessage = "Este campo deve conter no máximo 255 caracteres")]
        public string Photo { get; private set; }

        [MaxLength(255, ErrorMessage = "Este campo deve conter no máximo 255 caracteres")]
        public string BackImage { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DefaultValue(true)]
        public bool Active { get; private set; }

        public DateTime DateBirth { get; private set; }

        [DefaultValue(0)]
        public int Websocket { get; private set; }

        [DefaultValue(0)]
        public int FiveStarsRating { get; private set; }

        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Usuário inválido")]
        public long UserId { get; private set; }
        public User User { get; private set; }
    }
}