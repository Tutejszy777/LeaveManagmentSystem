﻿namespace LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR;

public class EmployeeListVM
{
    public string Id { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }


    [Display(Name = "Last Name")]
    public string LastName { get; set; }


    [Display(Name = "Email ")]
    public string Email { get; set; }
}