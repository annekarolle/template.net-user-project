using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreFIAP.Entity;
using StoreFIAP.Interface;
using StoreFIAP.Services;
using System.Linq;
using UserTemplate.Services;

namespace StoreFIAP.Repository
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        private readonly PasswordHasherService _passwordHasher;

        public EFUserRepository(ApplicationDbContext context, PasswordHasherService passwordHasher) : base(context)
        {
            _passwordHasher = passwordHasher;
        }

       
        /// <summary>
        /// Faz a verificação das credenciais passadas e retorna o usuário.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUserByNameAndPassword(string email, string password)
        {   
            var user = _context.User.FirstOrDefault(user => user.Email == email);

            bool isValidCredentials = _passwordHasher.VerifyPassword(user.Password, password);
                if(isValidCredentials)
                {
                return user;
                }

            return null;
        }
    }
}
