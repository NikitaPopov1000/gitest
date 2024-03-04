using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public SearchController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("find")]
        public async Task<IActionResult> Find([FromBody] string searchText)
        {
            // Реализация поиска в базе данных или через GitHubService
            var searchResults = await _dbContext.SearchResult
                .Where(r => EF.Functions.Like(r.SearchText, $"%{searchText}%"))
                .ToListAsync();

            return Ok(searchResults);
        }

        [HttpGet("find")]
        public async Task<IActionResult> GetFindResults()
        {
            // Получение всех результатов поиска из базы данных
            var searchResults = await _dbContext.SearchResult.ToListAsync();

            return Ok(searchResults);
        }

        [HttpDelete("find/{id}")]
        public async Task<IActionResult> DeleteFindResult(int id)
        {
            // Удаление результата поиска по идентификатору
            var searchResult = await _dbContext.SearchResult.FindAsync(id);
            if (searchResult == null)
            {
                return NotFound();
            }

            _dbContext.SearchResult.Remove(searchResult);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}