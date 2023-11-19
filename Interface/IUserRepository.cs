using StoreFIAP.Entity;

namespace StoreFIAP.Interface
{
    public interface IUserRepository : IRepository<User>
    {
     
     /// <summary>
     /// Retorna o usuário encontrado com os parametros passados
     /// </summary>
     /// <param Email="Email"></param>
     /// <param password="password"></param>
     /// <returns></returns>
        User GetUserByNameAndPassword(string email, string password); 


        

    }
}
