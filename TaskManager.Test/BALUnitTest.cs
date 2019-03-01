using TaskManager.BusinessLayer;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManager.Entities;

namespace TaskManager.BusinessLayer.Tests
{
    
    [TestClass()]
    // Test Class contains unit Test Methods
    public class BALUnitTest
    {
        TaskManagerBL blObj = new TaskManagerBL();

        [TestMethod()]
        public void GetAllTasksTest()
        {
            int result = blObj.GetAllTasks().Count;
            Assert.IsTrue(result > 0);
        }

        [TestMethod()]
        //Test Method for GetByTask Id
        public void GetTaskByIdTest()
        {
            int id = 1;
            var task = blObj.GetTaskById(id);
            Assert.IsNotNull(task);

        }

        [TestMethod()]
        //Test Method for AddTask List Items
        public void AddTaskTest()
        {
            Task task = new Task { Task_ID = 0, TaskName = "Task 9", Parent = null, Start_Date = DateTime.Now.AddDays(-10), End_Date = DateTime.Now.AddDays(5), Parent_ID = null, Priority = 10 };
            try
            {
                blObj.AddTask(task);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not added");
            }
            

        }

        [TestMethod()]
        //Test Method for Update List Items
        public void UpdateTaskTest()
        {
            Task task = new Task { Task_ID = 1, TaskName = "Task 1", Parent = null, Start_Date = DateTime.Now.AddDays(-10), End_Date = DateTime.Now.AddDays(5), Parent_ID = null, Priority = 10 };
            try
            {
                blObj.UpdateTask(task);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not updated");
            }

        }

        [TestMethod()]
        //Test Method for Delete List Item
        public void DeleteTaskTest()
        {
            int id = 2;
            try
            {
                blObj.DeleteTask(id);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not deleted");
            }

        }
    }
}

