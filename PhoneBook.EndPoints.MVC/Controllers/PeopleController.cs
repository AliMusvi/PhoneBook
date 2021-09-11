using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Contracts.People;
using PhoneBook.Core.Contracts.Tags;
using PhoneBook.Domain.Core;
using PhoneBook.Domain.Core.People;
using PhoneBook.EndPoints.MVC.Models.People;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.MVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonRepository personRepository;
        private readonly ITagRepository tagRepository;

        public PeopleController(IPersonRepository personRepository, ITagRepository tagRepository)
        {
            this.personRepository = personRepository;
            this.tagRepository = tagRepository;
        }
        public IActionResult Index()
        {
            var people = personRepository.GetAll().ToList();
            return View(people);
        }

        public IActionResult Add()
        {
            var model = new AddNewPersonDisplayViewModel();
            model.TagsForDisplay = tagRepository.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddNewPersonGetViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person Person = new Person()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Email = model.Email,
                    Tags = new List<PersonTag>(model.SelectedTags.Select(c => new PersonTag
                    {
                        TagId = c
                    }).ToList()),
                };

                if (model?.Image?.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        model.Image.CopyTo(memoryStream);
                        var fileBytes = memoryStream.ToArray();
                        Person.Image = Convert.ToBase64String(fileBytes);
                    }
                }
                personRepository.Add(Person);
                return RedirectToAction("Index");
            }

            var modelforDisplay = new AddNewPersonDisplayViewModel
            {
                Address = model.Address,
                Email = model.Email,
                LastName = model.LastName,
                FirstName = model.FirstName
            };
            modelforDisplay.TagsForDisplay = tagRepository.GetAll().ToList();
            return View(modelforDisplay);
        }
    }
}
