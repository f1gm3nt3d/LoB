using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Dawn.Game
{
    class Mob
    {
        public string Name { get; set; }
        public List<Stat> Stats { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Effect> Effects { get; set; }
        public List<Item> Inventory { get; set; }
        public bool Male { get; set; }

        public int RollStats(Stat[] stats)
        {
            NumGen number = new NumGen((uint)System.DateTime.Today.Millisecond);
            int total = 0;
            foreach (Stat stat in stats)
            {
                for (int i = 0; i < (int)stat.Value; i++)
                {
                    total += number.Next(6);
                }
            }
            return total / stats.Length;
        }

    }
}
