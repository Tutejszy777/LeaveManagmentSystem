namespace LeaveManagmentSystem.Data
{
    public class AppicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}
