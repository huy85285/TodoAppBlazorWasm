using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using TodoList.Models.Enums;

namespace TodoAppBlazor.Api.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        [Required]
        public String Name{ get; set; }
        public Guid? AssigneeId{ get; set; }
        [ForeignKey(nameof(AssigneeId))]
        public virtual User? Assignee { get; set; }
        public DateTime CreatedDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
