namespace ManagementSystemCodeFirstWithExistingDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeDetailsId { get; set; }

        public int Phone { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        /*   [Required] 
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        */
        public virtual Employee Employee { get; set; }
    }
}
