using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Dawn.Game
{
    class Item
    {
        public String Name { get; set; }
        public String ShortDescription { get; set; }
        public String LongDescription { get; set; }
        public List<Effect> Effects { get; set; }
        public float Weight { get; set; }
        public int Value { get; set; }
        public bool Drinkable { get; set; }
        public bool Eatable { get; set; }
        
    }
}
