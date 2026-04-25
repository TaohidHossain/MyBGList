using Microsoft.AspNetCore.Mvc;
using MyBGList.Models;
using MyBGList.DTO;

namespace MyBGList.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
public class BoardGamesController(ILogger<BoardGamesController> logger): ControllerBase
{
    private readonly ILogger<BoardGamesController> _logger = logger;

    [HttpGet(Name= "GetBoardGames")]
    public RestDTO<BoardGame[]> Get()
    {
        return new RestDTO<BoardGame[]>
        {
            Data = [
                new() {
                    Id = 1,
                    Name = "Axis & Allies",
                    Year = 1981,
                    MinPlayer = 2,
                    MaxPlayer = 5
                },
                new()
                {
                    Id = 2,
                    Name = "Citadels",
                    Year = 2000,
                    MinPlayer = 2,
                    MaxPlayer = 8
                },
                new()
                {
                    Id = 3,
                    Name = "Terraforming Mars",
                    Year = 2016,
                    MinPlayer = 1,
                    MaxPlayer = 5
                }
            ],
            Links = [
                new()
                {
                    Href = Url.Action(null, "BoardGames", null, Request.Scheme)!,
                    Rel = "self",
                    Method = "GET"
                }
            ]
        };
    }
}