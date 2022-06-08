namespace WebApplication1.Models
{
    //Creatung Model, Blueprint which represents the data
    public class TodoItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}
