using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace LeaveManagementSystem.Application.Models.LeaveRequestDIR
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [DisplayName("Start Date")]
        [Required]
        public DateOnly DateOnly { get; set; }

        [DisplayName("End Date")]
        [Required]
        public DateOnly DateEnd { get; set; }

        [DisplayName("Leave type")]
        [Required]
        public int LeaveTypeId { get; set; }

        [DisplayName("Additional information")]
        [StringLength(250)]
        public string? RequestComments { get; set; }

        public SelectList? LeaveTypeList { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOnly > DateEnd)
            {
                yield return new ValidationResult("The start date must be before the end date", new[] { nameof(DateOnly), nameof(DateEnd) });
            }
        }
    }
}