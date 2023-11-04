using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models.Enums;

namespace TodoList.Models
{
    public class TaskCreateRequest
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        [Required]
        public String Name { get; set; }
        public Priority Priority { get; set; }
    }
}
