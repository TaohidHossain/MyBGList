namespace MyBGList.DTO;

public record LinkDTO()
{
    public string Href { get; init; } = string.Empty;
    public string Rel { get; init; } = string.Empty;
    public string Method { get; init; } = string.Empty;
}