﻿using Microsoft.AspNetCore.Mvc;
using StoreFIAP.DTO;
using StoreFIAP.Interface;
using StoreFIAP.Services;
using UserTemplate.Services;

namespace StoreFIAP.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService  _tokenService;
        private readonly PasswordHasherService _passwordHasher;

        public LoginController(IUserRepository userRepository, ITokenService tokenService, PasswordHasherService passwordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Rota de autenticação de Usuário
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Authenticate([FromBody ] LoginDTO login)
        {
            var user = _userRepository.GetUserByNameAndPassword(login.Email, login.Password);          

            if (user == null)
                return NotFound(new { message = "Email or Password invalid" });

            var token = _tokenService.GetToken(user);

            user.Password = null;

            return Ok(new
            {
                User = user,
                Token = token
            });

        }
    }
}
