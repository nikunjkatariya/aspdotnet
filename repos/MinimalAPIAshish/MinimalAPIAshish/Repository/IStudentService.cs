namespace MinimalAPIAshish.Repository
{
    public interface IStudentService
    {
        Task<IResult> GetStudents();
    }
}
