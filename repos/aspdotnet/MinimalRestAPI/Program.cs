global using Microsoft.EntityFrameworkCore;
using MinimalRestAPI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("api"));

builder.Services.AddScoped<IArticleService, ArticleService>();

var app = builder.Build();

//Get Request
app.MapGet("/articles",async(IArticleService articleService)=>
    await articleService.GetArticles());

//Get Single Request
app.MapGet("/articles/{id}", async (int id,IArticleService articleService) =>
     await articleService.GetArticleById(id));

//Post Request
app.MapPost("/articles", async (ArticleRequest articleRequest,IArticleService articleService) =>
     await articleService.CreateArticle(articleRequest));

//Update Request
app.MapPut("/articles/{id}", async (int id, ArticleRequest articleRequest, IArticleService articleService) =>
     await articleService.UpdateArticle(id,articleRequest));

//Delete Request
app.MapDelete("/articles/{id}", async (int id, IArticleService articleService) =>
     await articleService.DeleteArticle(id));

    //app.MapGet("/",() => "Hello Beutiful World!");
//app.MapGet("/", () => MyHandler.hello());
//app.MapGet("/sum",()=>"Sum Method");
//app.MapGet("/sum", (int ? n1) => n1);
//app.MapGet("/sum",(int ? n1,int ? n2)=> n1 + n2 );
//app.MapGet("/",()=> new Todo { FirstName = "Mosh", LastName = "Jonshon" });
//app.Urls.Add("http://localhost:3000");
//app.Urls.Add("http://localhost:3001");

app.Run();

class MyHandler
{
    public static string hello()
    {
        return "Hello World";
    }
}

class Todo
{
    public string? FirstName{ get; set; }
    public string? LastName{ get; set; }    
}