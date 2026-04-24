using Microsoft.AspNetCore.Mvc;
using MyBGList.Models;

namespace MyBGList.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
public class BoardGamesController(ILogger<BoardGamesController> logger)
{
    private readonly ILogger<BoardGamesController> _logger = logger;

    [HttpGet(Name= "GetBoardGames")]
    public IEnumerable<BoardGame> Get()
    {
        return new[]
        {
            new BoardGame
            {
                Id = 1,
                Name = "Axis & Allies",
                Year = 1981,
                MinPlayer = 2,
                MaxPlayer = 5
            },
            new BoardGame
            {
                Id = 2,
                Name = "Citadels",
                Year = 2000,
                MinPlayer = 2,
                MaxPlayer = 8
            },
            new BoardGame
            {
                Id = 3,
                Name = "Terraforming Mars",
                Year = 2016,
                MinPlayer = 1,
                MaxPlayer = 5
            }
        };
    }
}