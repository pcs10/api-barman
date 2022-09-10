using Barman.Models;

namespace Barman.Interfaces
{
    public interface IDrinkRepository
    {
        Task<IEnumerable<Drink>> BuscarTodos();
        //Task<string> Inserir(Usuario usuario);
        //Task<string> Alterar(Usuario usuario, int id);
        //Task<Usuario> BuscarPorId(int id);
        //Task<string> Excluir(int id);
    }
}
