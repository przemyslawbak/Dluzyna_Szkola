using Microsoft.AspNetCore.Identity;

namespace DluzynaSzkola2.Models
{
    public enum QualificationLevels
    {
        Brak, Podstawowe, Zaawansowane
    }

    public class AppUser : IdentityUser
    {
        public QualificationLevels Qualifications { get; set; }
    }
}
