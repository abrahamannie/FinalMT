using System;
using System.Collections.Generic;

namespace AssetManagementWebAPI.Models
{
    public partial class AssetDefinition
    {
        public AssetDefinition()
        {
            AssetMasterAmAd = new HashSet<AssetMaster>();
            AssetMasterAmMake = new HashSet<AssetMaster>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public decimal AdId { get; set; }
        public string AdName { get; set; }
        public decimal? AdTypeId { get; set; }

        public virtual AssetType AdType { get; set; }
        public virtual ICollection<AssetMaster> AssetMasterAmAd { get; set; }
        public virtual ICollection<AssetMaster> AssetMasterAmMake { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
