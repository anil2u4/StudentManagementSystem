using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{

    public class StudentsController:Controller
    {
        
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public Task<string>Get()
        {
            return this.GetStudent();
        }

              private async Task<string>GetStudent()
        {
            var students = await _studentRepository.Get();
            return JsonConvert.SerializeObject(students);
        }
        [HttpGet]
        public Task<string> Get(string id)
        {
            return this.GetStudentById(id);
        }

        private async Task<string> GetStudentById(string id)
        {
            var student= await _studentRepository.Get(id) ?? new Student();
            return JsonConvert.SerializeObject(student);
        }
        [HttpPost]
        public async Task<string>Post([FromBody]Student student)
        {
            await _studentRepository.Add(student);
            return "";
        }
        [HttpPut("{id}")]
        public async Task<string> Put(string id,[FromBody]Student student)
        {
            if (string.IsNullOrEmpty(id)) return "invalid id !!!";
            return await _studentRepository.Update(id, student);
        }
        [HttpDelete("{id}")]
        public async Task<string>Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return "invalid id !!!";
            await _studentRepository.Remove(id);
            return "";
        }
    }
}
