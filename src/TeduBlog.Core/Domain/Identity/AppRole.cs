using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduBlog.Core.Domain.Identity;

[Table("AppRoles")]
public class AppRole : IdentityRole<Guid>
{
    [Required]
    [MaxLength(200)]
    public required string DisplayName{ get; set; }
}
