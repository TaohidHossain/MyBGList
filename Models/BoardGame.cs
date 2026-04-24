namespace MyBGList.Models;
public class BoardGame
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? Year { get; set; }
    public int? MinPlayer { get; set; }
    public int? MaxPlayer { get; set; }
}