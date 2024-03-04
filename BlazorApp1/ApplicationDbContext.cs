using Microsoft.EntityFrameworkCore;

namespace BlazorApp1 // Замените YourNamespace на актуальное пространство имен вашего проекта
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<SearchResult> SearchResult { get; set; }
        // Здесь вы можете добавить DbSet для ваших моделей данных
    }
}