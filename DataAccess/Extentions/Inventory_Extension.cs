namespace DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Inventory
    {
        [NotMapped]
        public string InventoryTypeName { get; set; }
        [NotMapped]
        public bool IsAddedToStock { get; set; }
        [NotMapped]
        public int NumberCount { get; set; }
    }
}
