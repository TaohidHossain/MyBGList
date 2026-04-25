namespace MyBGList.DTO;

public record RestDTO<T>
{
    public List<LinkDTO> Links { get; set; } = [];
    public T Data { get; set; } = default!;
}