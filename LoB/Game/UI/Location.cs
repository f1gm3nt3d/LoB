using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Dawn.Game
{
    public class Location
    {
        public List<Menu> Places { get; set; }
        //LongDescription is used for look and is displayed on the first visit.
        public string LongDescription { get; set; }
        public bool Visited { get; set; }
        public int LocationX = 0;
        public int LocationY = 0;

        public Location()
        {
            this.Places = new List<Menu>();
        }

    }
}
