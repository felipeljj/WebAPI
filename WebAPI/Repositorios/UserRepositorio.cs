using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositorios.Interface;

namespace WebAPI.Repositorios
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly SistemaUserDbContext _dbContext;

        public UserRepositorio(SistemaUserDbContext sistemaUserDbContext) 
        {
            _dbContext = sistemaUserDbContext;
        }

        public async Task<UserModel> BuscarPorId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> BuscarTodosUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserModel> Adicionar(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user; 
        }
        public async Task<UserModel> Atualizar(UserModel user,int id)
        {
            UserModel userPorID = await BuscarPorId(id);
            if (userPorID == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados");
            }
            userPorID.name = user.name;
            userPorID.email = user.email;

            _dbContext.Users.Update(userPorID);
            await _dbContext.SaveChangesAsync();

            return userPorID;
        }

        public async Task<bool> Apagar(int id)
        {
            UserModel userPorID = await BuscarPorId(id);
            if (userPorID == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Users.Remove(userPorID);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
