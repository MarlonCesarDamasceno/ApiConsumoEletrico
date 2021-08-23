using System;
using System.Collections.Generic;

#nullable disable

namespace ApiConsumoEletrico.Persistence
{
    public partial class HouseProfile
    {
        public HouseProfile()
        {
            Electronics = new HashSet<Electronic>();
        }

        public int HouseProfileId { get; set; }
        public string HouseName { get; set; }
        public int Dealership { get; set; }
        public int ProfileUser { get; set; }

        public virtual Dealership DealershipNavigation { get; set; }
        public virtual User ProfileUserNavigation { get; set; }
        public virtual ICollection<Electronic> Electronics { get; set; }
    }
}
