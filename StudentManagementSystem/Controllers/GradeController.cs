using BLL.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IStudentSubjectGradeService studentSubjectGradeService;

        public GradeController(IStudentSubjectGradeService studentSubjectGradeService)
        {
            this.studentSubjectGradeService = studentSubjectGradeService;
        }
        [Authorize]
        [HttpPost("AddDegree")]
        public async Task<IActionResult> AddDegree(int Studnet_Id,int Subject_Id,int degree)
        {
            var result= await studentSubjectGradeService.AddStudentGradeInSubject(Studnet_Id,Subject_Id, degree);
            return Ok(result);
        }
        [HttpPatch("UpdateDegree")]
        public async Task<IActionResult> UpdateDegree(int Studnet_Id, int Subject_Id, int degree)
        {
            var result = await studentSubjectGradeService.UpdateStudentGradeInSubject(Studnet_Id, Subject_Id, degree);
            return Ok(result);
        }
        [HttpDelete("DeleteDegree")]
        public async Task<IActionResult> DeleteDegree(int Studnet_Id, int Subject_Id)
        {
            var result = await studentSubjectGradeService.DeleteStudentGradeInSubject(Studnet_Id, Subject_Id);
            return Ok(result);
        }
        [HttpGet("GetDegress")]
        public async Task<IActionResult> GetDegress(int Studnet_Id)
        {
            var result = await studentSubjectGradeService.GetAllStudent(Studnet_Id);
            return Ok(result);
        }
    }
}
