using System;
using System.Collections.Generic;

namespace AssetManagementWebAPI.Models
{
    public partial class AssetType
    {
        public AssetType()
        {
            AssetDefinition = new HashSet<AssetDefinition>();
            Vendor = new HashSet<Vendor>();
        }

        public decimal AtId { get; set; }
        public string AtName { get; set; }

        public virtual ICollection<AssetDefinition> AssetDefinition { get; set; }
        public virtual ICollection<Vendor> Vendor { get; set; }
    }
}
