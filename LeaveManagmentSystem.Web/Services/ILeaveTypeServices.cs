using LeaveManagmentSystem.Web.Models.LeaveTypes;

namespace LeaveManagmentSystem.Web.Services
{
    public interface ILeaveTypeServices
    {
        Task Create(LeaveTypeCreateVM model);
        Task Edit(LeaveTypeEditVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<IndexReadOnlyVM>> GetAllLeaveTypesAsync();
        Task Remove(int id);
    }
}