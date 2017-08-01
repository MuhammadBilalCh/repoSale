namespace DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Employee
    {
        [NotMapped]
        public string EmployeeTypeName { get; set; }
    }
}
