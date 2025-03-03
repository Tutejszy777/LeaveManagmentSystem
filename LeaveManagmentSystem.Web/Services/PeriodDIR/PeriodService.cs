using Microsoft.EntityFrameworkCore;

namespace LeaveManagmentSystem.Web.Services.PeriodDIR
{
    public class PeriodService(ApplicationDbContext _context) : IPeriodService
    {
        public async Task<Period> GetCurrentPeriod()
        {
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);

            return period;
        }
    }
}
