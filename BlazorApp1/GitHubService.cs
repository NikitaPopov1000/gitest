using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp1
{
    public class GitHubService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly HttpClient _httpClient;

        public GitHubService(ApplicationDbContext dbContext, HttpClient httpClient)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
        }

        public async Task SearchAndSaveResultsAsync(string searchText)
        {
            // Отправка запроса к API GitHub
            var response = await _httpClient.GetAsync($"https://api.github.com/search/repositories?q={searchText}");
            response.EnsureSuccessStatusCode(); // Генерация исключения в случае ошибки HTTP

            var json = await response.Content.ReadAsStringAsync();

            // Сохранение результатов в базу данных
            var searchResult = new SearchResult
            {
                SearchText = searchText,
                ResultJson = json
            };

            _dbContext.SearchResult.Add(searchResult);
            await _dbContext.SaveChangesAsync();
        }
    }
}