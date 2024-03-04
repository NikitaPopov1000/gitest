using System.Collections.Generic;

namespace BlazorApp1 // Замените YourNamespace на актуальное пространство имен вашего проекта
{
    public class AppStateService
    {
        public string CurrentSearchText { get; set; }
        public List<SearchResult> SearchResults { get; set; } = new List<SearchResult>();
    }
}