using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Infrastructure.Interfaces;
using Market.ViewModels;

namespace Market.Infrastructure.Services
{
    public class InMemoryUserService: IUserServices
    {
        public List<UserViewModel> StartUser = new List<UserViewModel>
        {
            new UserViewModel
            {
                Id = 1,
                LastName = "Медведев",
                FirstName = "Дмитрий",
                MiddleName = "Анатольевич",
                DateOfBirth = Convert.ToDateTime("14.09.1965"),
                Login = "Medvedev",
                Score = 1000000,
                Password = "qwe"
            },
            new UserViewModel
            {
                Id = 2,
                LastName = "Путин",
                FirstName = "Владимир",
                MiddleName = "Владимирович",
                DateOfBirth = Convert.ToDateTime("07.10.1952"),
                Login = "Putin",
                Score = 1000000,
                Password = "qwe"
            },
            new UserViewModel
            {
                Id = 3,
                LastName = "Ельцин",
                FirstName = "Борис",
                MiddleName = "Николаевич",
                DateOfBirth = Convert.ToDateTime("01.02.1931"),
                Login = "Elcin",
                Score = 1000000,
                Password = "qwe"
            }
        };
        public IEnumerable<UserViewModel> GetAll()
        {
            return StartUser;
        }

        public UserViewModel GetById(int id)
        {
            UserViewModel user = StartUser.SingleOrDefault(c => c.Id == id);
            return user;

        }

        public void Commit()
        {
            
        }

        public void AddNewUser(UserViewModel user)
        {
            user.Id = StartUser.Max(c => c.Id) + 1;
            StartUser.Add(user);
        }

        public void Delete(int id)
        {
            UserViewModel user = StartUser.SingleOrDefault(c => c.Id == id);
            if (user is null)
                return;
            StartUser.Remove(user);
        }
    }
}
