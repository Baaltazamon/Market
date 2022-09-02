using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.ViewModels;

namespace Market.Infrastructure.Interfaces
{
    public interface IUserServices
    {
        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserViewModel> GetAll();

        /// <summary>
        /// Получение пользователя по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserViewModel GetById(int id);

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        void Commit();

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="user"></param>
        void AddNewUser(UserViewModel user);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

    }
}
