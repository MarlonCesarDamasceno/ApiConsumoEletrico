using System;
using System.Collections.Generic;

#nullable disable

namespace ApiConsumoEletrico.Persistence
{
    public partial class Electronic
    {
        public int ElectronicsId { get; set; }
        public string ElectronicsName { get; set; }
        public double ElectronicsPotency { get; set; }
        public double UsageTimePerDay { get; set; }
        public int UsedInHouse { get; set; }

        public virtual HouseProfile UsedInHouseNavigation { get; set; }
    }
}
