using System.ComponentModel.DataAnnotations;    

namespace LeaveManagmentSystem.Web.Models.LeaveTypes
{
    public class  LeaveTypeCreateVM
    {
        [Required]
        [Length(4,150,ErrorMessage ="You have length violated requirments")]
        public string Name { get; set; }
        [Required]
        [Range(1, 90, ErrorMessage = "You have range violated requirments")]
        [Display(Name = "Days left")]
        public int DefaultDays { get; set; }
    }
}
