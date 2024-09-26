using WebAPI.Models;

namespace WebAPI.Repositorios.Interface
{
    public interface IUserRepositorio
    {
        Task<List<UserModel>> BuscarTodosUsers();
        Task<UserModel> BuscarPorId(int id);
        Task<UserModel> Adicionar(UserModel user);
        Task<UserModel> Atualizar(UserModel user, int id);
        Task<bool> Apagar(int id);
    }
} 
