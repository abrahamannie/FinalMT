using System;
using System.Collections.Generic;

namespace AssetManagementWebAPI.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            AssetMaster = new HashSet<AssetMaster>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public decimal VdId { get; set; }
        public string VdName { get; set; }
        public string VdType { get; set; }
        public decimal? VdAtypeId { get; set; }
        public DateTime? VdFrom { get; set; }
        public DateTime? VdTo { get; set; }
        public string VdAddress { get; set; }

        public virtual AssetType VdAtype { get; set; }
        public virtual ICollection<AssetMaster> AssetMaster { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
