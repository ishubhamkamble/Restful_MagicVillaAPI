using Microsoft.EntityFrameworkCore;
using Restful_MagicVillaAPI.Models;

namespace Restful_MagicVillaAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Villa> Villas { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }
        
    }
}
