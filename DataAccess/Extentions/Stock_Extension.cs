namespace DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Stock
    {
        [NotMapped]
        public int InventoryTypeId { get; set; }
        [NotMapped]
        public string InventoryTypeName { get; set; }
        [NotMapped]
        public string InventoryName { get; set; }
        [NotMapped]
        public string InventoryNumber { get; set; }
    }
}
