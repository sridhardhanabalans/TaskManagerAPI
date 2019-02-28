using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Entities;
using TaskManager.BusinessLayer;
using System.Web.Http.Description;



namespace TaskManager.API.Controllers
{
    public class TaskController : ApiController
    {
        TaskManagerBL blObject = null;

        [HttpGet]
        [Route("api/Task/GetAllTasks")]
        [ResponseType(typeof(List<Task>))]
        public IHttpActionResult GetAllTasks()
        {
            blObject = new TaskManagerBL();
            List<Task> tasks = blObject.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet]
        [Route("api/Task/GetTaskById/{Id}")]
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTaskById(int Id)
        {
            blObject = new TaskManagerBL();
            Task task= blObject.GetTaskById(Id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        [Route("api/Task/AddTask")]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddTask([FromBody]Task newTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            blObject = new TaskManagerBL();
            blObject.AddTask(newTask);
            return Ok();
        }

        [HttpPut]
        [Route("api/Task/UpdateTask")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateTask([FromBody]Task editTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            blObject = new TaskManagerBL();
            blObject.UpdateTask(editTask);
            return Ok();
        }

        [HttpDelete]
        [Route("api/Task/DeleteTask/{Id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteTask(int Id)
        {
            blObject = new TaskManagerBL();
            blObject.DeleteTask(Id);
            return Ok();
        }

    }
}
