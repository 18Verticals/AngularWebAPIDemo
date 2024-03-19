using BLL.Services;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        public ITaskService _service { get; }

        public TaskController(ITaskService service)
        {
            _service = service;
        }


        [HttpGet("GetTasks")]
        public async Task<TaskList_DTO> GetTasks()
        {
            return await _service.GetTasks();
        }

        [HttpGet("GetTaskById/{Id}")]
        public async Task<TaskModel> GetDepartmentById(int Id)
        {
            return await _service.GetTaskById(Id);
        }

        [HttpPost("AddTask")]
        public async Task<TaskModel> AddTask(AddTaskRequest_DTO request)
        {
            return await _service.AddTask(request);
        }
        [HttpPost("UpdateTask")]
        public async Task<TaskModel> UpdateTask(UpdateTaskRequest_DTO request)
        {
            return await _service.UpdateTask(request);
        }

        [HttpDelete("DeleteTask/{Id}")]
        public async Task<TaskModel> DeleteTask(int Id)
        {
            return await _service.DeleteTask(Id);
        }

        [HttpGet("GetTaskByAssignedId/{Id}")]
        public async Task<TaskList_DTO> GetTaskByAssignedId(int Id)
        {
            return await _service.GetTaskByAssignedId(Id);
        }



    }
}
