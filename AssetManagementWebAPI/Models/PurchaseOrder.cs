using System;
using System.Collections.Generic;

namespace AssetManagementWebAPI.Models
{
    public partial class PurchaseOrder
    {
        public decimal PdId { get; set; }
        public decimal? PdOrderNo { get; set; }
        public decimal? PdAdId { get; set; }
        public decimal? PdTypeId { get; set; }
        public decimal? PdQty { get; set; }
        public decimal? PdVendorId { get; set; }
        public DateTime? PdDate { get; set; }
        public DateTime? PdDdate { get; set; }
        public string PdStatus { get; set; }

        public virtual AssetDefinition PdAd { get; set; }
        public virtual Vendor PdVendor { get; set; }
    }
}
