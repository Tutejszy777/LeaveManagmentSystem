

namespace LeaveManagmentSystem.Web.Services.Users
{
    public interface IUserService
    {
        Task<List<AppicationUser>> GetEmployees();
        Task<AppicationUser> GetLoggedInUser();
        Task<AppicationUser> GetUserById(string userId);
    }
}