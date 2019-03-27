using Microsoft.EntityFrameworkCore;
using PM.Web.Persons.DataModels;

namespace PM.Web.Data
{
    public class PMContext: DbContext
    {
        public PMContext(DbContextOptions<PMContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
