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

        public async Task<string> Inserir(Drink drink)
        {
            //verificar se o nome drink com esse nome ja existe
            var drinkComparacao = await _context
                .Drinks
                .FirstOrDefaultAsync(dc => dc.Nome == drink.Nome);

            if (drinkComparacao != null)
            {
                return "Nome de drink já existe";
            }
            else
            {
                try
                {
                    await _context.Drinks.AddAsync(drink);
                    await _context.SaveChangesAsync();
                    return "";
                }catch (Exception ex)
                {
                    return "Erro ao inserir (Repositório) -> " + ex;
                }
            }
        }// inserir

        public async Task<string> Alterar(Drink drinkModel, int id)
        {
            //verificar se existe drink com o id informado
            var drinkAlterar = await _context
                .Drinks
                .AsNoTracking()
                .FirstOrDefaultAsync(da => da.Id == id);

            if (drinkAlterar == null)
            {
                return "Drink não encontrado";
            }

            //verificar se existe algum outro usuario com o mesmo nome de usuário passado
            var drinkAlterar2 = await _context
                 .Drinks
                 .AsNoTracking()
                 .FirstOrDefaultAsync(da2 => da2.Id != id && da2.Nome == drinkModel.Nome);


            if (drinkAlterar2 != null)
                return "Nome do Drink já existe";

            if (drinkModel.Nome.Length < 3 || drinkModel.Nome.Length > 50)
                return "O nome do Drink deve conter entre 3 e 50 caracteres";


            drinkModel.Id = id; // add o id no modelo

            // se não for passado preco no alterar, pegar senha que ja tinha
            if (drinkModel.Preco == null) drinkModel.Preco = drinkAlterar.Preco;

            try
            {
                // _context.Usuarios.Update(usuario);
                _context.Entry(drinkModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return "Erro ao atualizar -> " + ex;
            }

        }//alterar

        public async Task<string> Excluir(int id)
        {
            var drink = await _context
                 .Drinks
                 .FirstOrDefaultAsync(x => x.Id == id);

            if (drink == null) return "Drink não encontrado";

            try
            {
                _context.Drinks.Remove(drink);
                await _context.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return "Erro ao excluir -> " + ex;
            }
        } //excluir

        public async Task<Drink> BuscarPorId(int id)
        {
            var drink = await _context
                 .Drinks
                 .FirstOrDefaultAsync(x => x.Id == id);

            return drink;
        }// buscar por ID



    }
}
