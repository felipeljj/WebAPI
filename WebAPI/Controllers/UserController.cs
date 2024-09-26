using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositorios.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositorio _userRepositorio;

        public UserController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio; 
        }


        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> BuscarTodosUsuarios()
        {
            List<UserModel> users = await _userRepositorio.BuscarTodosUsers();
            return Ok(users);
        }

        [HttpGet("{id})")]
        public async Task<ActionResult<UserModel>> BuscarPorId(int id)
        {
            UserModel user = await _userRepositorio.BuscarPorId(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Cadastrar([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepositorio.Adicionar(userModel);
            return Ok(user);
        }
    }
}
