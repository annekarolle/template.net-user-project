using Microsoft.AspNetCore.Identity;
using StoreFIAP.DTO;
using StoreFIAP.Enums;
using UserTemplate.Services;

namespace StoreFIAP.Entity
{
    /// <summary>
    /// Representa um usuário no sistema, contendo informações essenciais e métodos relacionados. Herda propriedade Id de Entitys
    /// </summary>
    public class User : Entitys
    {       

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    
        public PermitionsTypes Permitions { get; set; }
        public bool IsActived { get; set; }
      
        

        public User() { }

        /// <summary>
        /// Cria uma nova instância da classe User com as informações fornecidas, pelo SaveUserDTO
        /// </summary>
        /// <param name="userName">O nome do usuário.</param>
        /// <param name="email">O endereço de e-mail do usuário.</param>
        /// <param name="password">A senha do usuário.</param>
        /// <param Permitions="permitions">Tipo de permissão do usuário no sistema.</param>
        public User(SaveUserDTO saveUserDTO, PasswordHasherService passwordHasher)
        {
            Name = saveUserDTO.Name;
            Email = saveUserDTO.Email;
            Password = passwordHasher.HashPassword(saveUserDTO.Password);
            Permitions = saveUserDTO.Permitions;
            IsActived = true;
            CreatedDate = DateTime.UtcNow;
        }

        public void DesactiveUser(int id)
        {
            IsActived = false;
            DesactivedDate = DateTime.Now;
        }

        public void ChangeUserPassword(string NewPassword, PasswordHasherService passwordHasher)
        {
            Password = passwordHasher.HashPassword(NewPassword);
            UpdatedDate = DateTime.Now;
        }
    }
}
