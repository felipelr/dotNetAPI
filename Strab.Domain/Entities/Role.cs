using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Strab.Domain.Entities
{
    [Table("Roles")]
    public class Role
    {
        public Role(int id, string displayName, string name)
        {
            Id = id;
            DisplayName = displayName;
            Name = name;
        }

        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(150, ErrorMessage = "Este campo deve conter no máximo 150 caracteres")]
        public string DisplayName { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(150, ErrorMessage = "Este campo deve conter no máximo 150 caracteres")]
        public string Name { get; private set; }
    }
}