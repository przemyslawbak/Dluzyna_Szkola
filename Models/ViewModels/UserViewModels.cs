using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DluzynaSzkola2.Models.ViewModels
{
    public class CreateModel
    {
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Password { get; set; }
    }
    public class LoginModel
    {
        [Required]
        [UIHint("email")]
        public string Email { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }
    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}
