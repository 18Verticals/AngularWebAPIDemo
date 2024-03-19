using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ITaskRepo
    {
        Task<TaskList_DTO> GetTasks();
        Task<TaskModel> GetTaskById(int Id);
        Task<TaskModel> AddTask(AddTaskRequest_DTO request);
        Task<TaskModel> UpdateTask(UpdateTaskRequest_DTO request);
        Task<TaskModel> DeleteTask(int Id);
        Task<TaskList_DTO> GetTaskByAssignedId(int Id);

    }
}
