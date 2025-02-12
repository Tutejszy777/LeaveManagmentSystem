using LeaveManagmentSystem.Web.Models.LeaveTypes;

namespace LeaveManagmentSystem.Web.Services.LeaveTypes;

public interface ILeaveTypeServices
{
    Task<bool> CheckIfLeaveNameExists(string name);
    Task<bool> CheckIfLeaveNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit);
    Task Create(LeaveTypeCreateVM model);
    Task Edit(LeaveTypeEditVM model);
    Task<T?> Get<T>(int id) where T : class;
    Task<List<IndexReadOnlyVM>> GetAllLeaveTypesAsync();
    bool LeaveTypeExists(int id);
    Task Remove(int id);
}