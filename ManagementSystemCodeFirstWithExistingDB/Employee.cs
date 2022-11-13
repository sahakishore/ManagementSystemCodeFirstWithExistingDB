namespace ManagementSystemCodeFirstWithExistingDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual EmployeeDetail EmployeeDetail { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
