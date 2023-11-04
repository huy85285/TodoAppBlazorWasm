using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TodoAppBlazor.Api.Entities
{
    public class Role:IdentityRole<Guid>
    {
        [MaxLength(50)]
        [Required]
        public String Desciption { get; set; }
    }
}
