using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Dawn.Game
{
    public enum Level
    {
        Legendary=8,
        Epic=7,
        Fantastic=6,
        Superb=5,
        Great=4,
        Good=3,
        Fair=2,
        Average=1,
        Mediocre=0,
        Poor=-1,
        Terrible=-2,
        Abysmal=-3
    }

    public enum CommandType
    {
        Location,
        Command,
        Script,
        GameScript
    }

    public enum CharacterPage
    {
        Main,
        ActiveSkill,
        PassiveSkill,
        Inventory,
        Spells
    }
}
