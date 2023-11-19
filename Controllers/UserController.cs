using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreFIAP.DTO;
using StoreFIAP.Entity;
using StoreFIAP.Enums;
using StoreFIAP.Interface;
using UserTemplate.Services;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private IUserRepository _userRepository;
    private readonly ILogger<UserController> _logger;
    private readonly PasswordHasherService _passwordHasher;

    public UserController(IUserRepository userRepository, ILogger<UserController> logger, PasswordHasherService passwordHasher)
    {
        _userRepository = userRepository;
        _logger = logger;
        _passwordHasher = passwordHasher;
    }

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="userDTO"></param>
    /// <returns></returns>     

    [HttpPost("saveUser")]
    public IActionResult SaveUser(SaveUserDTO userDTO)
    {
      
        _userRepository.Save(new User(userDTO, _passwordHasher));
       
        var message = $"User {userDTO.Name} created with sucess!";
        _logger.LogWarning(message);
        return Ok(message);
    }

    /// <summary>
    /// Obtém todos os usuários, o método necessita de autenticação e permissão de Administrador
    /// </summary>
    /// <returns></returns>
    /// <response code="200"> Retonar Sucesso</response>
    /// <response code="401"> Não Autenticado</response>
    /// <response code="403"> Ñão Autorizado</response>
    [Authorize]
    [Authorize(Roles = Permitions.Admin)]
    [HttpGet("getAllUser")]
    public IActionResult GetAllUser()
    {
        return Ok(_userRepository.GetAll());
    }


    /// <summary>
    ///  Obtém todos os usuários, o método necessita de autenticação e permissão de Administrador
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200"> Retonar Sucesso</response>
    /// <response code="401"> Não Autenticado</response>
    /// <response code="403"> Ñão Autorizado</response>
    /// <response code="404"> Usuário não encontrado</response>
    [Authorize]
    [Authorize(Roles = Permitions.Admin)]
    [HttpGet("getUserById/{id}")]
    public IActionResult GetUserById(int id)
    {
        return Ok(_userRepository.GetById(id));
    }


    /// <summary>
    /// Modifica dados do usuário, método necessita de autenticação.
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200"> Retonar Sucesso</response>
    /// <response code="401"> Não Autenticado</response> 
    /// <response code="404"> Usuário não encontrado</response>
    [Authorize]
    [HttpPut("putUser/{id}")]
    public IActionResult PutUser(int id)
    {
        var user = _userRepository.GetById(id);

        if (user == null)
            return NotFound("Usuário não encontrado");

        _userRepository.Put(user);
        return Ok("Usuario alterado com sucesso");
    }

    /// <summary>
    /// Deleta usuário, o método necessita de permissão de Administrador.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200"> Retonar Sucesso</response>
    /// <response code="401"> Não Autenticado</response>
    /// <response code="403"> Ñão Autorizado</response>
    /// <response code="404"> Usuário não encontrado</response>
    [Authorize]
    [Authorize(Roles = Permitions.Admin)]
    [HttpDelete("deleteUser/{id}")]
    public IActionResult DeleteUser(int id)
    {
        _userRepository.Delete(id);
        return Ok("Usuario deletado com sucesso");
    }
}
