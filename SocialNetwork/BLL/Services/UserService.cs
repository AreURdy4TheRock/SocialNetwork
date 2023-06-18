using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class UserService
    {
        IUserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }
        public void Register(UserRegistrarionData userRegistrarionData)
        {
            if (String.IsNullOrEmpty(userRegistrarionData.FirstName))
            {
                throw new ArgumentException();
            }
            if (String.IsNullOrEmpty (userRegistrarionData.LastName))
            {
                throw new ArgumentException();
            }
            if (String.IsNullOrEmpty (userRegistrarionData.Password))
            {
                throw new ArgumentException();
            }
            if (String.IsNullOrEmpty (userRegistrarionData.Email))
            {
                throw new ArgumentException();
            }

            if (userRegistrarionData.Password.Length < 8)
            {
                throw new ArgumentException();
            }
            if (!new EmailAddressAttribute().IsValid(userRegistrarionData.Email))
            {
                throw new ArgumentException();
            }
            if(userRepository.FindByEmail(userRegistrarionData.Email) != null)
            {
                throw new ArgumentException();
            }

            var userEntity = new UserEntity()
            {
                firstname = userRegistrarionData.FirstName,
                lastname = userRegistrarionData.LastName,
                email = userRegistrarionData.Email,
                password = userRegistrarionData.Password
            };
            if (this.userRepository.Create(userEntity) == 0) 
            {
                throw new Exception();
            }

        }
    }
}
