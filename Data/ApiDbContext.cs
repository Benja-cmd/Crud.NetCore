namespace capaCensys2.Data
{
    using capaCensys2.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        {
                    
        }

        public virtual DbSet<Persona> Personas { get; set; }

        

    }
}
