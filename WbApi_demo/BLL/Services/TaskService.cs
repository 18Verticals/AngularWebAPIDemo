using Azure.Core;
using DAL.Repositories;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TaskService : ITaskService
    {
        public TaskService(ITaskRepo repo)
        {
            Repo = repo;
        }

        public ITaskRepo Repo { get; }

        public async Task<TaskModel> AddTask(AddTaskRequest_DTO request)
        {
            return await Repo.AddTask(request);
        }

        public async Task<TaskModel> DeleteTask(int Id)
        {
            return await Repo.DeleteTask(Id);
        }

        public async Task<TaskList_DTO> GetTaskByAssignedId(int Id)
        {
            return await Repo.GetTaskByAssignedId(Id);
        }

        public async Task<TaskModel> GetTaskById(int Id)
        {
            return await Repo.GetTaskById(Id);
        }

        public async Task<TaskList_DTO> GetTasks()
        {
            return await Repo.GetTasks();
        }

        public async Task<TaskModel> UpdateTask(UpdateTaskRequest_DTO request)
        {
            return await Repo.UpdateTask(request);
        }
    }
}
