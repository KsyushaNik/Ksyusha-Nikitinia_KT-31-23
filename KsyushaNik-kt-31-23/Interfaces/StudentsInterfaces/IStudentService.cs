using Microsoft.EntityFrameworkCore;
using KsyushaNik_kt_31_23.Database;
using KsyushaNik_kt_31_23.Filters.StudentFilters;
using KsyushaNik_kt_31_23.Models;

namespace KsyushaNik_kt_31_23.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
        Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;

        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>()
                .Where(w => w.Group != null && w.Group.GroupName == filter.GroupName)
                .ToArrayAsync(cancellationToken);

            return students;
        }
    }
}