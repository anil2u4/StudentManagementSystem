using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {

        private readonly IStudentRepository _studentRepository;
        public StudentApiController(IStudentRepository _studentRepository)
        {
            this._studentRepository = _studentRepository;
        }

        public Task<string> Get()
        {
            return this.GetStudent();
        }

        private async Task<string> GetStudent()
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
            var student = await _studentRepository.Get(id) ?? new Student();
            return JsonConvert.SerializeObject(student);
        }
        [HttpPost]
        public async Task<string> Post([FromBody]Student student)
        {
            await _studentRepository.Add(student);
            return "";
        }
        [HttpPut("{id}")]
        public async Task<string> Put(string id, [FromBody]Student student)
        {
            if (string.IsNullOrEmpty(id)) return "invalid id !!!";
            return await _studentRepository.Update(id, student);
        }
        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return "invalid id !!!";
            await _studentRepository.Remove(id);
            return "";
        }
    }

 
}