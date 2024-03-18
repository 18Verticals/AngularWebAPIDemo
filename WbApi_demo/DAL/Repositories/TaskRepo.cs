using Azure.Core;
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

        public async Task<TaskModel> AddTask(AddTaskRequest_DTO request)
        {
            try
            {
                AppTask newTask = new AppTask
                {
                    AssignedId = request.AssignedId,
                    Description = request.Description,
                    EndDate = DateTime.Parse(request.EndDate),
                    StartDate = DateTime.Parse(request.StartDate),
                    Title = request.Title,
                    UserId = request.UserId,
                    Status = request.Status,

                };
                await _context.AddAsync(newTask);
                await _context.SaveChangesAsync();
                return new TaskModel
                {
                    IsSuccess = true,
                    Message = "Task has been added sucessfully."
                };
            }
            catch (Exception err)
            {

                return new TaskModel
                {
                    IsError = true,
                    Message = err.Message
                };
            }
        }

        public async Task<TaskModel> DeleteTask(int Id)
        {
            try
            {
                var existingTask = await _context.Tasks.FindAsync(Id);
                if (existingTask == null)
                {
                    throw new Exception("Task does not exist.");
                }

                _context.Tasks.Remove(existingTask);
                return new TaskModel
                {
                    IsSuccess = true,
                    Message = "Task has been deleted sucessfully."
                };
            }
            catch (Exception err)
            {

                return new TaskModel
                {
                    IsError = true,
                    Message = err.Message
                }; 
            }
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
                        Status = task.Status,
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
                            UserId = item.UserId,
                            Status = item.Status,

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

        public async Task<TaskModel> UpdateTask(UpdateTaskRequest_DTO request)
        {

            try
            {
                var existingTask = await _context.Tasks.FindAsync(request.Id);
                if (existingTask == null)
                {
                    throw new Exception("Task does not exist.");
                }

                existingTask.AssignedId = request.AssignedId;
                existingTask.Title = request.Title;
                existingTask.Description = request.Description;
                existingTask.EndDate = DateTime.Parse(request.EndDate);
                existingTask.StartDate = DateTime.Parse(request.StartDate);
                existingTask.UserId = request.UserId;
                existingTask.Status = request.Status;
                await _context.SaveChangesAsync();
                return new TaskModel
                {
                    IsSuccess = true,
                    Message = "Task has been updates sucessfully"
                };
            }
            catch (Exception err)
            {
                return new TaskModel
                {
                    IsError = true,
                    Message = err.Message
                };
            }
        }
    }
}
