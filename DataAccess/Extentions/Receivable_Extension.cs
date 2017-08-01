namespace DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Receivable
    {
        [NotMapped]
        public string EmployeeName { get; set; }
    }
}
