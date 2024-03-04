namespace BlazorApp1
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string SearchText { get; set; }
        public string ResultJson { get; set; }
        public string ProjectName { get; set; } // Добавлено свойство для имени проекта
        public string Author { get; set; } // Добавлено свойство для автора проекта
        public int StargazersCount { get; set; } // Добавлено свойство для количества звезд
        public int WatchersCount { get; set; } // Добавлено свойство для количества просмотров
        public string RepositoryUrl { get; set; } // Добавлено свойство для ссылки на репозиторий
    }
}