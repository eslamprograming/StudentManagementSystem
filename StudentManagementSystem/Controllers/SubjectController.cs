using BLL.IService;
using DAL.ModelVM.SubjectVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SubjectManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISupjectService _SubjectService;

        public SubjectController(ISupjectService SubjectService)
        {
            _SubjectService = SubjectService;
        }
        [HttpPost("CreateSubject")]
        public async Task<IActionResult> CreateSubject(RegisterSubject Subject)
        {
            var result = await _SubjectService.CreateSubjectAsync(Subject);
            return Ok(result);
        }
        [HttpGet("GetAllSubject")]
        public async Task<IActionResult> GetAllSubject(int GroupNumber)
        {
            var result = await _SubjectService.GetAllSubjectAsync(GroupNumber);
            return Ok(result);
        }
        [HttpGet("GetSubject")]
        public async Task<IActionResult> GetSubject(int Subject_Id)
        {
            var result = await _SubjectService.GetSubjectAsync(Subject_Id);
            return Ok(result);
        }
        [HttpDelete("DeleteSubject")]
        public async Task<IActionResult> DeleteSubject(int Subject_Id)
        {
            var result = await _SubjectService.DeleteSubjectAsync(Subject_Id);
            return Ok(result);
        }
        [HttpPut("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(int SubjectId, RegisterSubject Subject)
        {
            var result = await _SubjectService.UpdateSubjectAsync(SubjectId, Subject);
            return Ok(result);
        }

    }
}
