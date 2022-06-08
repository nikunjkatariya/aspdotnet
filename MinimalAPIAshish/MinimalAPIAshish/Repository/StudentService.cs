using Microsoft.EntityFrameworkCore;
using MinimalAPIAshish.Models;

namespace MinimalAPIAshish.Repository
{
    public class StudentService : IStudentService
    {
        public readonly StudentContext _context;
        public StudentService(StudentContext context)
        {
            _context=context;
        }
        public async Task<IResult> GetStudents()
        {
            return Results.Ok(await _context.Students.ToListAsync());
        }
    }
}
