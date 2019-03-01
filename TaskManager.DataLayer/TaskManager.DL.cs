using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.DataLayer
{
    //Class for DAL Layer for Service
    public class TaskManagerDAL
    {
        
        //Method to return all task items
        public List<Task> GetAllTasks()
        {
            TaskContext taskContext = new TaskContext();
            return taskContext.Tasks.ToList();
        }
        //Method to return specific task on search
        public Task GetTaskById(int Id)
        {
            TaskContext taskContext = new TaskContext();
            return taskContext.Tasks.Where(m => m.Task_ID == Id).FirstOrDefault();
        }
        //Method to add new task item from UI
        public void AddTask(Task newTask)
        {
            TaskContext taskContext = new TaskContext();
            taskContext.Tasks.Add(newTask);
            taskContext.SaveChanges();
        }
        //Method to update task item from UI
        public void UpdateTask(Task editTask)
        {
            TaskContext taskContext = new TaskContext();
            var existingTask = taskContext.Tasks.Where(m => m.Task_ID == editTask.Task_ID).FirstOrDefault();

            existingTask.Parent_ID = editTask.Parent_ID;
            existingTask.TaskName = editTask.TaskName;
            existingTask.Start_Date = editTask.Start_Date;
            existingTask.End_Date = editTask.End_Date;
            existingTask.Priority = editTask.Priority;

            taskContext.SaveChanges();
        }
        //Method to delete existing task item from UI
        public void DeleteTask(int id)
        {
            TaskContext taskContext = new TaskContext();
            TaskContext newContext = new TaskContext();
            var parentIdTasks = taskContext.Tasks.Where(m => m.Parent_ID == id);
            if (parentIdTasks.Count() == 0)
            {
                return;
            }
            foreach (var item in parentIdTasks)
            {
                var existingTask = newContext.Tasks.Where(m => m.Task_ID == item.Task_ID).FirstOrDefault();
                existingTask.Parent_ID = null;
                newContext.SaveChanges();
            }

            var deleteTask= taskContext.Tasks.Where(m => m.Task_ID == id).FirstOrDefault();
            taskContext.Tasks.Remove(deleteTask);
            taskContext.SaveChanges();
        }

    }
}
