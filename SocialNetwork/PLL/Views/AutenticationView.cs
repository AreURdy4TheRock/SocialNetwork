using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class AutenticationView
    {
        UserService userService;
        public AutenticationView(UserService userService)
        {
            this.userService = userService;
        }
        public void Show()
        {
            var autenticationData = new UserAuthenticationData();
            Console.WriteLine("Введите почтовый адрес: ");
            autenticationData.Email = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            autenticationData.Password = Console.ReadLine();

            try
            {
                var user = this.userService.Authenticate(autenticationData);
                SuccessMessage.Show("Вы успешно вошли в социальную сеть!");
                SuccessMessage.Show("Добро пожаловать, " + user.FirstName);
                Program.userMenuView.Show(user);
            }
            catch (WrongPasswordException)
            {
                AlertMessage.Show("Пароль некорректный!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
        }
    }
}
