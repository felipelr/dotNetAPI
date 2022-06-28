namespace Strab.Domain.Dtos;
public class ClientDTO
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string Document { get; private set; } = "";
    public string Gender { get; private set; } = "";
    public string Phone { get; private set; } = "";
    public string Photo { get; private set; } = "";
    public DateTime DateBirth { get; private set; }
    public long UserId { get; private set; }
}