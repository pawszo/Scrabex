using Microsoft.EntityFrameworkCore;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }


    }
}
