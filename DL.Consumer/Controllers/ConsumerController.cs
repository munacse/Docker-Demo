using System.Collections.Generic;
using System.Threading.Tasks;
using DL.Consumer.Model;
using DL.Consumer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DL.Consumer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ConsumerController : Controller
    {
        private readonly IStudentInfoRepository studentInfoRepository;

        public ConsumerController(IStudentInfoRepository studentInfoRepository)
        {
            this.studentInfoRepository = studentInfoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentInfo>> Get()
        {
            var students = await studentInfoRepository.GetAsync();
            return students;
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<StudentInfo> Get(int id)
        {
            var student = await studentInfoRepository.GetAsync(id);
            return student;
        }

        [HttpDelete("{id}", Name = "RemoveStudent")]
        public async Task<bool> RemoveStudent(int id)
        {
            return await studentInfoRepository.DeleteAsync(id);
        }
    }
}