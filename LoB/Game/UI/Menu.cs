using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Dawn.Game
{
    public class Menu
    {
        public string Name { get; set; }
        public string Special { get; set; }
        public string Text { get; set; }
        public SerializableDictionary<string,Command> Commands { get; set; }
        public string Prompt { get; set; }
        public int PromptTop { get; set; }
        public int PromptLeft { get; set; }

        public Menu()
        {
            this.Commands = new SerializableDictionary<string,Command>();
            this.Prompt = "Enter your choice: ";
        }
    }
}
