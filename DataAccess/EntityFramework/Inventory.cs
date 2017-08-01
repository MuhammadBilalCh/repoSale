//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory()
        {
            this.Sales = new HashSet<Sale>();
            this.Stocks = new HashSet<Stock>();
        }
    
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public string InventoryNumber { get; set; }
        public decimal InitialPrice { get; set; }
        public System.DateTime CurrentDate { get; set; }
        public string Description { get; set; }
        public int InventoryTypeId { get; set; }
        public string BarCode { get; set; }
    
        public virtual InventoryType InventoryType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}