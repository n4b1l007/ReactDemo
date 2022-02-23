using TestApi.Data.Interfaces;
using TestApi.Entities;

namespace TestApi.Data.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
