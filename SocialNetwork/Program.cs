using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть!");
            while (true)
            {
                Console.Write("Для регистрации пользователя введите имя: ");
                string firstName = Console.ReadLine();
                Console.Write("фамилию: ");
                string lastName = Console.ReadLine();
                Console.Write("пароль: ");
                string password = Console.ReadLine();
                Console.Write("почтовый адрес: ");
                string email = Console.ReadLine();
                UserRegistrarionData userRegistrarionData = new UserRegistrarionData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };

                try
                {
                    userService.Register(userRegistrarionData);
                    Console.WriteLine("Регистрация произошла успешно!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введите корректное значение!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Произошла ошибка при регистрации!");
                }
                Console.ReadKey();
            }
        }
    }
}
