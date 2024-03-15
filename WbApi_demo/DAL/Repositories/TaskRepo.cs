using DAL.Data;
using DAL.Entities;
using DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TaskRepo : ITaskRepo
    {
        public TaskRepo(DataContext context)
        {
            _context = context;
        }

        public DataContext _context { get; }

        public Task<TaskModel> AddTask(AddTaskRequest_DTO request)
        {
            throw new NotImplementedException();
        }

        public Task<TaskModel> DeleteTask(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskModel> GetTaskById(int Id)
        {
            try
            {
                AppTask task = await _context.Tasks.FindAsync(Id);
                if (task != null)
                {
                    return new TaskModel
                    {
                        AssignedId = task.AssignedId,
                        Description = task.Description,
                        EndDate = task.EndDate,
                        Id = task.Id,
                        StartDate = task.StartDate,
                        Title = task.Title,
                        UserId = task.UserId,
                        Message = "sucess",
                        IsSuccess = true
                    };
                }
                else
                {
                    throw new Exception("No task exist");
                }
            }
            catch (Exception err)
            {
                return new TaskModel
                {

                    Message = err.Message,
                    IsError = true
                };
            }

        }

        public async Task<TaskList_DTO> GetTasks()
        {
            try
            {
                List<AppTask> taskList = await _context.Tasks.ToListAsync();
                List<AppTaskModel> tasks = new List<AppTaskModel>();
                foreach (var item in taskList)
                {
                    tasks.Add(
                        new AppTaskModel
                        {
                            Id = item.Id,
                            AssignedId = item.AssignedId,
                            Description = item.Description,
                            EndDate = item.EndDate,
                            StartDate = item.StartDate,
                            Title = item.Title,
                            UserId = item.UserId
                        });
                }

                if (taskList.Count == 0)
                {
                    return new TaskList_DTO
                    {
                        tasks = tasks,
                        IsInformation = true,
                        Message = "No Tasks available"
                    };
                }
                return new TaskList_DTO
                {
                    tasks = tasks,
                    IsSuccess = true,
                    Message = "Sucessfull"
                };
            }
            catch (Exception err)
            {
                return new TaskList_DTO
                {
                    IsError = true,
                    Message = err.Message
                };
            }
      
        }

        public Task<TaskModel> UpdateTask(AddTaskRequest_DTO request)
        {
            throw new NotImplementedException();
        }
    }
}
