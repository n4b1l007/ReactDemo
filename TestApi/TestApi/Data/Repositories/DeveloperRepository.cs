using System.Collections.Generic;
using System.Linq;
using TestApi.Data.Interfaces;
using TestApi.Entities;

namespace TestApi.Data.Repositories
{
    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Developer> GetPopularDevelopers(int count)
        {
            return _context.Developers.Take(count).ToList();
        }
    }
}
