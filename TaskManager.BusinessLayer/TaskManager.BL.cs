using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Entities;
using TaskManager.DataLayer;

namespace TaskManager.BusinessLayer
{
    public class TaskManagerBL
    {
        TaskManagerDAL dalObj = null;
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

        public Task GetTaskById(int Id)
        {
            dalObj = new TaskManagerDAL();
            return dalObj.GetTaskById(Id);
        }

        public void AddTask(Task newTask)
        {
            dalObj = new TaskManagerDAL();
            dalObj.AddTask(newTask);
        }

        public void UpdateTask(Task editTask)
        {
            dalObj = new TaskManagerDAL();
            dalObj.UpdateTask(editTask);
        }

        public void DeleteTask(int id)
        {
            dalObj = new TaskManagerDAL();
            dalObj.DeleteTask(id);
        }
    }
}
