﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagmentSystem.Web.Data
{
    public class LeaveType : BaseEntity
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
