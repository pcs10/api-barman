using Barman.Data;
using Barman.Interfaces;
using Barman.Models;
using Microsoft.EntityFrameworkCore;

namespace Barman.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        //deixar o contexto fora para que nao precise toda horas ficar passando ele entre parametros
        private readonly AppDbContext _context;
        public DrinkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Drink>> BuscarTodos()
        {
            var drinks = await _context
                            .Drinks
                            .AsNoTracking()
                            .ToListAsync();

            return drinks;
        }// buscar todos

       
    }
}
