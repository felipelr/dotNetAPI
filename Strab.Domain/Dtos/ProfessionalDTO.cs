namespace Strab.Domain.Dtos;
public class ProfessionalDTO
{
    public long Id { get; private set; }
    public string Name { get; private set; } = "";
    public string Description { get; private set; } = "";
    public string Document { get; private set; } = "";
    public string Phone { get; private set; } = "";
    public string Photo { get; private set; } = "";
    public string BackImage { get; private set; } = "";
    public DateTime DateBirth { get; private set; }
    public int FiveStarsRating { get; private set; }
    public long UserId { get; private set; }
}