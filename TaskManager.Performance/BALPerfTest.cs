using NBench;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using TaskManager.BusinessLayer;
using TaskManager.Entities;

namespace TaskManager.Performance
{
    public class BALPerfTest
    {
        TaskManagerBL blObj = new TaskManagerBL();

        [PerfBenchmark(Description = "To check if the Fetch all tasks executes within 3 seconds", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 3000)]

        public void GetAllTasksTest()
        {
            blObj.GetAllTasks();
        }

        [PerfBenchmark(Description = "To measure the memory allocated", RunTimeMilliseconds = 2000, NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, SkipWarmups = true)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void GetTaskByIdTest()
        {
            int id = 1;
            blObj.GetTaskById(id);
        }

        [PerfBenchmark(Description = "To check the garbage collections efficiency", NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]

        public void AddTaskTest()
        {
            Task task = new Task { Task_ID = 0, TaskName = "Task 9", Parent = null, Start_Date = DateTime.Now.AddDays(-10), End_Date = DateTime.Now.AddDays(5), Parent_ID = null, Priority = 10 };
            blObj.AddTask(task);
        }

        [PerfBenchmark(Description = "To verify if the memory allocated inside the block is more than 64 KB", NumberOfIterations = 3, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.SixtyFourKb)]
        public void UpdateTaskTest()
        {
            Task task = new Task { Task_ID = 1, TaskName = "Task 1", Parent = null, Start_Date = DateTime.Now.AddDays(-10), End_Date = DateTime.Now.AddDays(5), Parent_ID = null, Priority = 10 };
            blObj.UpdateTask(task);

        }

        [PerfBenchmark(Description = "To find out the performance of the garbage collector", NumberOfIterations = 5, RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void DeleteTaskTest()
        {
            int id = 2;
            blObj.DeleteTask(id);

        }
    }
}
