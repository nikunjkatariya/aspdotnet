namespace MinimalRestAPI
{
    public record ArticleRequest(string? Title, string? Content, DateTime PublishedAt) { }
}
