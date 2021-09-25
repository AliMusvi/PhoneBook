using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.EndPoints.MVC.Models.AAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var users = userManager.Users.Take(50).ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = model.Email,
                    UserName = model.UserName
                };
                var result = userManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)               
                    return RedirectToAction("Index");                
                else
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
            }
            return View(model);
        }

        public IActionResult Update(string id)
        {
            var user = userManager.FindByIdAsync(id).Result; 
            if (user != null)
            {
                //این 3 خط زیر رو چرت و پرت گفت فک کنم
                //UpdateUserViewModel model = new UpdateUserViewModel
                //{
                //    Email = user.Email
                //};
                return View(user);
            }
            return NotFound();
        }

        [HttpPut]
        public IActionResult Upddate(string id, UpdateUserViewModel updateUserViewModel)
        {
            var user = userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                user.Email = updateUserViewModel.Email;
                var result = userManager.UpdateAsync(user).Result;
                //return View(user);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (var error in result.Errors)                   
                        ModelState.AddModelError(error.Code, error.Description);                    

                return View(updateUserViewModel);
            }
            return NotFound();
        }

        public IActionResult Delete(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                var result = userManager.DeleteAsync(user).Result;

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (var error in result.Errors)                    
                        ModelState.AddModelError(error.Code, error.Description);                                   
            }
            return View();
        }
    }
}
