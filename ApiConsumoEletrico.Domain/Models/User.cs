using System;
using System.Collections.Generic;

#nullable disable

namespace ApiConsumoEletrico.Persistence
{
    public partial class User
    {
        public User()
        {
            HouseProfiles = new HashSet<HouseProfile>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<HouseProfile> HouseProfiles { get; set; }
    }
}
