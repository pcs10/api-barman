using Barman.Models;

namespace Barman.Interfaces
{
    public interface IDrinkRepository
    {
        Task<IEnumerable<Drink>> BuscarTodos();
        Task<string> Inserir(Drink drink);
        Task<string> Alterar(Drink drinkModel, int id);
        Task<Drink> BuscarPorId(int id);
        Task<string> Excluir(int id);
    }
}
