using Microsoft.EntityFrameworkCore;
using Parcial2.Models;

namespace Parcial2.Context;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
            
        }
    
        public DbSet<Obra> Obra { get; set; }
        public DbSet<TiposObra> TiposObras { get; set; }


}