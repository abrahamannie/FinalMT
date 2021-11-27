using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Model
{
    public class AssetMasterList
    {
        public int AmId { get; set; }
        public decimal? PdOrderNo { get; set; }
        public string AmModel { get; set; }
        public string AmSnumber { get; set; }
        public string AmMyyear { get; set; }
        public DateTime? AmPdate { get; set; }
        public string AmWaranty { get; set; }
        public DateTime? AmForm { get; set; }
        public DateTime? AmTo { get; set; }
        public DateTime? PdDate { get; set; }
        public DateTime? PdDdate { get; set; }
        public string PdStatus { get; set; }
    }
}
