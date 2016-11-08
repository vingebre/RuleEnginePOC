using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEnginePOC
{
    public class Shipment
    {
        public string ServiceCode { get; set; }
        public string ServiceEditionCode { get; set; }
        public string ServiceOwner { get; set; }
        public string ShipmentHandler { get; set; }
        public string ShipmentType { get; set; }
        public string ArchiveReference { get; set; }
        public int ShipmentSize { get; set; }
    }
}
