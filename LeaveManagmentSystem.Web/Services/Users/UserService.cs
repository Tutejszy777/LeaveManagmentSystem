namespace LeaveManagmentSystem.Web.Services.Users;

public class UserService(UserManager<AppicationUser> _userManager, IHttpContextAccessor _httpContextAccessor) : IUserService
{
    public async Task<AppicationUser> GetLoggedInUser()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        return user;
    }

    public async Task<AppicationUser> GetUserById(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user;
    }

    public async Task<List<AppicationUser>> GetEmployees()
    {
        var users = await _userManager.GetUsersInRoleAsync("Employee");
        return users.ToList();
    }
}
