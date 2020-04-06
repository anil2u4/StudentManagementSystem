using MongoDB.Driver;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Get();
        Task<Student>Get (string id);
        Task Add(Student Student);
        Task<string> Update(string id,Student Student);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();

    }
}
