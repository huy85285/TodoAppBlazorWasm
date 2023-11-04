using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace TodoAppBlazor.Api.Entities
{
    public class User : IdentityUser<Guid>
    {
        [MaxLength(50)]
        [Required]
        public String FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public String LastName { get; set; }
    }
}
