
namespace MinimalRestAPI
{
    public class ArticleService:IArticleService
    {
        public readonly ApiContext _context;

        public ArticleService(ApiContext context)
        {
            _context = context;
        }
        //Get 
        public async Task<IResult> GetArticles()
        {
            return Results.Ok(await _context.Articles.ToListAsync());
        }
        //Get/{id}
        public async Task<IResult> GetArticleById(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            return article != null ? Results.Ok(article) : Results.NotFound();
        }
        public async Task<IResult> CreateArticle(ArticleRequest article)
        {
            var createarticle = _context.Articles.Add(new Article
            {
                Title = article.Title??String.Empty,
                Content = article.Content??String.Empty,
                PublishedAt=article.PublishedAt
            });
            await _context.SaveChangesAsync();
            return Results.Created($"/articles/" +
                $"{createarticle.Entity.Id}", createarticle.Entity);
        }
        public async Task<IResult> UpdateArticle(int id,ArticleRequest article)
        {
            var articleToUpdate = await _context.Articles.FindAsync(id);
            if (articleToUpdate == null)
            {
                return Results.NotFound();
            }
            if(article.Title != null)
            {
                articleToUpdate.Title = article.Title;
            }
            if (article.Content!= null)
            {
                articleToUpdate.Content= article.Content;
            }
            if (article.PublishedAt!= null)
            {
                articleToUpdate.PublishedAt= article.PublishedAt;
            }
            await _context.SaveChangesAsync();

            return Results.Ok(articleToUpdate);
        }
        public async Task<IResult> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if(article == null)
            {
                return Results.NotFound();
            }
            
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return Results.NoContent();
        }
    }
}
