using LeaveManagmentSystem.Web.Models.LeaveTypes;

namespace LeaveManagmentSystem.Web.Services.LeaveTypes;

public interface ILeaveTypeServices
{
    Task<bool> CheckIfLeaveNameExists(string name);
    Task<bool> CheckIfLeaveNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit);
    Task Create(LeaveTypeCreateVM model);
    Task<bool> DaysExceedMaximum(int leaveTypeId, int days);
    Task Edit(LeaveTypeEditVM model);
    Task<T?> Get<T>(int id) where T : class;
    Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypesAsync();
    bool LeaveTypeExists(int id);
    Task Remove(int id);
}