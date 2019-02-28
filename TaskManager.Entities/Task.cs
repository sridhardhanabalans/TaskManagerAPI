using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TaskManager.Entities
{
    [Table("Task")]
    public class Task
    {
        [Key]
        [JsonProperty(PropertyName = "taskId")]
        public int Task_ID { get; set; }
        [JsonProperty(PropertyName = "parentId")]
        public int? Parent_ID { get; set; }
        [Column("Task")]
        [MaxLength(100)]
        [JsonProperty(PropertyName = "taskName")]
        public string TaskName { get; set; }
        [Column(TypeName="Date")]
        [JsonProperty(PropertyName = "startDate")]
        public DateTime Start_Date { get; set; }
        [Column(TypeName ="Date")]
        [JsonProperty(PropertyName = "endDate")]
        public DateTime End_Date { get; set; }
        [JsonProperty(PropertyName = "priority")]
        public int Priority { get; set; }
        [JsonProperty(PropertyName = "parent")]
        [ForeignKey("Parent_ID")]
        public Task Parent { get; set; }
    }
}
