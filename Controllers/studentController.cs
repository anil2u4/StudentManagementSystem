using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Controllers
{
    public class studentController : Controller
    {
        private readonly IStudentRepository repo;
        public studentController(IStudentRepository repo) { this.repo = repo; }
     

    
        

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student newStudent)
        {
            repo.Add(newStudent);
            return RedirectToAction("Index");
        }


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Login1()
        {
            return View();
        }



    }
}