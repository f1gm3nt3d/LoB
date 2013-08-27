using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Dawn.Game
{
    class Effect
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String EffectDescription { get; set; }
        public int Duration { get; set; }
        public int Value { get; set; }
        public Stat EffectedStat { get; set; }
    }
}
