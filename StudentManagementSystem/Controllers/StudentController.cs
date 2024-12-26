using BLL.IService;
using DAL.Entities;
using DAL.ModelVM.StudentVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent(RegisterStudent student)
        {
            var result = await _studentService.CreateStudentAsync(student);
            return Ok(result);
        }
        [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent(int GroupNumber)
        {
            var result = await _studentService.GetAllStudentAsync(GroupNumber);
            return Ok(result);
        }
        [HttpGet("GetStudent")]
        public async Task<IActionResult> GetStudent(int Student_Id)
        {
            var result = await _studentService.GetStudentAsync(Student_Id);
            return Ok(result);
        }
        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int Student_Id)
        {
            var result = await _studentService.DeleteStudentAsync(Student_Id);
            return Ok(result);
        }
        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(int StudentId,RegisterStudent student)
        {
            var result = await _studentService.UpdateStudentAsync(StudentId,student);
            return Ok(result);
        }

    }
}
