using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Entities;
using TaskManager.DataLayer;

namespace TaskManager.BusinessLayer
{
    //Class used for Calling DAL Layer
    public class TaskManagerBL
    {
        TaskManagerDAL dalObj = null;
        //Method to Get All Tasks
        public List<Task> GetAllTasks()
        {
            dalObj = new TaskManagerDAL();
            List<Task> allTasks = dalObj.GetAllTasks();
            List<Task> finalTasks = new List<Task>();
            foreach (Task task in allTasks)
            {
                if (task.Parent == null)
                {
                    task.Parent = new Task { Task_ID=0, TaskName="", Parent=null,Parent_ID=0, Priority=0};
                }
                finalTasks.Add(task);
            }
            return finalTasks;
        }
        //Method to Get specific task
        public Task GetTaskById(int Id)
        {
            dalObj = new TaskManagerDAL();
            return dalObj.GetTaskById(Id);
        }
        //Method to Add task
        public void AddTask(Task newTask)
        {
            dalObj = new TaskManagerDAL();
            dalObj.AddTask(newTask);
        }
        //Method to Update task
        public void UpdateTask(Task editTask)
        {
            dalObj = new TaskManagerDAL();
            dalObj.UpdateTask(editTask);
        }
        //Method to Delete task
        public void DeleteTask(int id)
        {
            dalObj = new TaskManagerDAL();
            dalObj.DeleteTask(id);
        }
    }
}
