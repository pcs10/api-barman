using Barman.Models;
using Microsoft.EntityFrameworkCore;

namespace Barman.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Referenciando models a tabelas do banco
        public DbSet<Drink> Drinks { get; set; }

    }
}
