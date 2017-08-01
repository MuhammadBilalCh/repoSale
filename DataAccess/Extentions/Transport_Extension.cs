namespace DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Transport
    {
        [NotMapped]
        public string InventoryName { get; set; }
        [NotMapped]
        public string InventoryNumber { get; set; }
        [NotMapped]
        public string EmployeeName { get; set; }
    }
}
