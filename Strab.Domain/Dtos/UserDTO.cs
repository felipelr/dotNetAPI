namespace Strab.Domain.Dtos;
public class UserDTO
{
    public long Id { get; set; }
    public string Email { get; set; } = "";
    public string Role { get; set; } = "";
    public ClientDTO? Client { get; set; }
    public ProfessionalDTO? Professional { get; set; }
}