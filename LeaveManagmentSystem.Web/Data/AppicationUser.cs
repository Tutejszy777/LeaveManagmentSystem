using Microsoft.AspNetCore.Identity;

namespace LeaveManagmentSystem.Web.Data
{
    public class AppicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}
