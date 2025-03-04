﻿using BLL.IService;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectController : ControllerBase
    {
        private readonly IStudentSujectService _studentSujectService;

        public StudentSubjectController(IStudentSujectService studentSujectService)
        {
            _studentSujectService = studentSujectService;
        }
        [HttpPost("AddSubjectToStudent")]
        public async Task<IActionResult> AddSubjectToStudent(int StudentId, int subject_Id)
        {
            var result = await _studentSujectService.AddSujectsToStudentAsync(StudentId, subject_Id);
            return Ok(result);
        }
        [HttpDelete("DeleteSubjectFromStudent")]
        public async Task<IActionResult> DeleteSubjectFromStudent(int StudentId,int subject_Id)
        {
            var result = await _studentSujectService.DeleteSujectsToStudentAsync(StudentId, subject_Id);
            return Ok(result);
        }
        [HttpGet("GetSubjectFromStudent")]
        public async Task<IActionResult> GetSubjectFromStudent(int StudentId)
        {
            var result = await _studentSujectService.GetAllSubjectsForStudentAsync(StudentId);
            return Ok(result);
        }
        [HttpPut("UpdateSubjectToStudent")]
        public async Task<IActionResult> UpdateSubjectToStudent(int Student_Id, int OldsubjectsId, int newsubject_Id)
        {
            var result = await _studentSujectService.UpdateSujectsToStudentAsync(Student_Id, OldsubjectsId,newsubject_Id);
            return Ok(result);
        }
    }
}
