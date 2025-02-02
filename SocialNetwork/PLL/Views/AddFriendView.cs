using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.PLL.Helpers;
using SocialNetwork.BLL.Exceptions;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {

        UserService userService;

        public AddFriendView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            var userAddingFriendData = new UserAddingFriendData();

            Console.Write("Введите почтовый адрес получателя: ");
            userAddingFriendData.FriendEmail = Console.ReadLine();
            userAddingFriendData.UserId = user.Id;

            try
            {
                userService.AddFriend(userAddingFriendData);
                SuccessMessage.Show("Пользователь успешно добавлен!");
                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }
        }
    }
}
