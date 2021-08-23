using System;
using System.Collections.Generic;

#nullable disable

namespace ApiConsumoEletrico.Persistence
{
    public partial class Dealership
    {
        public Dealership()
        {
            HouseProfiles = new HashSet<HouseProfile>();
        }

        public int DealershipId { get; set; }
        public string DealershipName { get; set; }
        public string State { get; set; }
        public double KhwPrice { get; set; }

        public virtual ICollection<HouseProfile> HouseProfiles { get; set; }
    }
}
