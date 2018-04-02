using Canducci.EntityFramework.Repository.EFCore;
using Microsoft.EntityFrameworkCore;
namespace WebAppCore.Models
{
    public class RepositoryPeople : Repository<People>, IRepositoryPeople
    {
        public RepositoryPeople(DbContext context) : base(context)
        {
        }
    }
}
