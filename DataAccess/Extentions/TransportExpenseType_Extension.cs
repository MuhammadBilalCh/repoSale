namespace DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TransportExpenseType
    {
        [NotMapped]
        public string ExpenseTypeName { get; set; }
    }
}
