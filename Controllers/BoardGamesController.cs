using Microsoft.AspNetCore.Mvc;
using MyBGList.Models;
using MyBGList.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MyBGList.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
public class BoardGamesController(
    ILogger<BoardGamesController> logger,
    ApplicationDbContext context
    ): ControllerBase
{
    private readonly ILogger<BoardGamesController> _logger = logger;
    private readonly ApplicationDbContext _context = context;

    [HttpGet(Name= "GetBoardGames")]
    public async Task<RestDTO<BoardGame[]>> Get(
        int pageIndex = 0,
        int pageSize = 10,
        string? sortBy = "Name",
        string? sortOrder = "ASC",
        string? filterQuery = null)
    {
        var query = _context.BoardGames.AsQueryable();

        if (!string.IsNullOrEmpty(filterQuery))
        {
            query = query.Where(b => b.Name.Contains(filterQuery));
        } 
        
        var recordCount = await query.CountAsync();
        query = query
            .OrderBy($"{sortBy} {sortOrder}")
            .Skip(pageIndex * pageSize)
            .Take(pageSize);

        return new RestDTO<BoardGame[]>
        {
            Data = await query.ToArrayAsync(),
            PageIndex = pageIndex,
            PageSize = pageSize,
            RecordCount = recordCount,
            Links = [
                new()
                {
                    Href = Url.Action(null, "BoardGames", new { pageIndex, pageSize }, Request.Scheme)!,
                    Rel = "self",
                    Method = "GET"
                }
            ]
        };
    }
}