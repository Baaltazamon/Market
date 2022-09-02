using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Infrastructure.Interfaces;
using Market.Infrastructure.Services;
using Market.ViewModels;

namespace Market.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        // GET: UserControler
        public IActionResult Users()
        {
            
            return View(_userServices.GetAll());
        }

        // GET: UserControler/Details/5
        public ActionResult Details(int id)
        {
            var user = _userServices.GetById(id);
            if (user is null)
                return BadRequest("Такого пользователя не существует");
            else
                return View(user);
        }

        // GET: UserControler/Create
        public ActionResult Create()
        {
            return View();
        }

  

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new UserViewModel());
            var user = _userServices.GetById(id.Value);
            if (user is null)
                return NotFound();
            return View(user);
        }

        // POST: UserControler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            if (user.Id > 0)
            {
                var userEdit = _userServices.GetById(user.Id);
                if (userEdit is null)
                    return NotFound();
                userEdit.FirstName = user.FirstName;
                userEdit.DateOfBirth = user.DateOfBirth;
                userEdit.Login = user.Login;
                userEdit.Password = user.Password;
                userEdit.LastName = user.LastName;
                userEdit.MiddleName = user.MiddleName;
                userEdit.Score = user.Score;
            }
            else
            {
                _userServices.AddNewUser(user);
            }
            _userServices.Commit();
            return RedirectToAction("Users");
        }

        // GET: UserControler/Delete/5
        public ActionResult Delete(int id)
        {
            _userServices.Delete(id);
            return RedirectToAction("Users");
        }

      
    }
}
