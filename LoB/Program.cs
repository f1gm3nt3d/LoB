using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using New_Dawn.Game;
using CSScriptLibrary;

namespace New_Dawn
{
    public interface IHelloScript
    {
        string hello(string name);
    }

    
    class Program
    {
        static ColorWriter Out = new ColorWriter();

        static void Main(string[] args)
        {   
            Console.BufferHeight = 25;
            List<Stat> Stats = FileUtils.DeserializeJson(typeof(List<Stat>), ".//Assets//BaseStats.json") as List<Stat>;
            
            Console.SetOut(Out);
            DisplayTitle();
            Console.Clear();
            MainMenu();            
        }

        static void DoBattle(string BattleType)
        {
            Out.WriteLine(string.Format("Battle type {0} not Implemented.\r\nPress enter to continue.",BattleType));
            Console.ReadLine();
        }

        #region Test setup
        static Location TestLocation()
        {

            Location StartingTown = new Location();
            New_Dawn.Game.Menu Main = (FileUtils.Deserialize(typeof(Menu),"./Assets/Menus/Evervale.xml")) as Menu;
            StartingTown.Places.Add(Main);           
            return StartingTown;
        }
        #endregion

        #region Display functions

        static void DrawStats()
        {
            int Left, Top = 0;
            Left= Console.CursorLeft;
            Top = Console.CursorTop;
            Console.CursorTop = 19;
            Console.CursorLeft = 0;
            string stats = "`6╔═════════════════════════════════════════════════════════════════════════════╗\r\n"+
                           "║ `7Name:                                             `7Xp: `40000000000/0000000000 `6║\r\n"+
                           "║ `7Health: `%000/000  `7Fatigue: `2000/000  `8Essence: `5000/000 `7[Press `!'F1' `7for help]   `6║\r\n" +
                           "║ `7Gold: `30000000000/0000000000                         `7[Press `!'F2'`7 for details]`6║\r\n" +
                           "╚═════════════════════════════════════════════════════════════════════════════╝`8\r\n";
            Console.Write(stats);
            Console.CursorTop = Top;
            Console.CursorLeft = Left;
        }

        static void DisplayTitle()
        {
            Console.Clear();
            System.IO.StreamReader SR = new StreamReader("./Assets/TitleScreenColor.txt");
            Console.Write(SR.ReadToEnd());
            Console.CursorLeft = 25;
            Console.CursorTop = 24; 
            Out.WriteCenter("Press (Enter) to continue ...",false,true);
            Console.ReadLine();
            Console.Clear();
        }

        static void MainMenu()
        {
            
            Menu main = FileUtils.Deserialize(typeof(Menu), ".//Assets//Menus/MainMenu.xml") as Menu;
            Console.WriteLine(main.Text);
            Console.CursorTop = main.PromptTop;
            Console.CursorLeft = main.PromptLeft;
            string choice = Input.GetUserInput(main.Prompt).ToLower();
            Player currentPlayer = null;
            while (choice != "d")
            {
                switch (choice)
                {
                    case "b":
                            //TODO: go to character creation
                        currentPlayer=CreateCharacter();
                        break;
                    case "a":
                            //TODO: go to character log in screen.
                        break;
                    default:
                        InvalidInput();
                        break;

                }
                //TODO: if currentPlayer isn't null then play the game
                //if(currentPlayer!=null)
                Console.Clear();
                Console.WriteLine(main.Text);
                Console.CursorTop = 18;
                Console.CursorLeft = 18;
                choice = Input.GetUserInput(main.Prompt, "");
            }
        }

        static void InvalidInput()
        {
            //TODO select a random error taunt string.
            string error =
@"`1  .--------------------------------------------------------.  
`1 /                                                          \ 
`1|    `5Did you forget something? Maybe you should stop`1         |
`1|    `5talking gibberish and try again.`1                        |
`1|                                                            |
`1|    `5Yeesh.`1                                                  |
`1|                                                            |
`1 \    `5<Hit Enter to try again>`1                              / 
`1  '--------------------------------------------------------'  `.";
            Out.WriteCenter(error,true,true);
            Console.ReadLine();
        }

        static Player CreateCharacter()
        {
            //TODO: Eventually export this out to CsScript
            //TODO: I'd like to randomize the starting story a little bit.
            //TODO: Add a quick create option where you enter the name, sex, stats, skills, etc. without a story.
            Player newPlayer = new Player();
            DisplayCharScreenBack();
            Console.CursorTop = 3;
            Out.WriteCenter("`5A Humble Beginning", false, true);
            Console.CursorLeft = 6;
            Out.WriteLeftAlignToColumn(
@"You yawn as you wake and stretch your arms out wide only to
be  stopped short by a rough wooden surface. Where the crumb are
you? Whats up with all the bouncing around? But perhaps most
importantly...

What the crud is your name?", true, 10);
            newPlayer.Name=Input.GetUserInput(" `.");
            string input = "";
            while (input != "b" && input != "g")
            {
                DisplayCharScreenBack();
                Console.CursorTop = 3;
                Out.WriteCenter("`5What an interesting feeling", false, true);
                Console.CursorLeft = 6;
                
                Out.WriteLeftAlignToColumn(
    string.Format(@"You heave a sigh of relief as you remember that at least some
people call you {0} among other, less memorable names. 

You're just starting to think that things are beginning to look 
up when gravity makes a prompt exit from your small, dark,
cramped world. You barely get to enjoy the feeling when gravity
decides that it misses you and your world very dearly. There is
a loud crashing sound and you groan as you blink in the sudden
brightness and dust yourself off. Yup, all your stinky `#(B)`5oy 
parts/silly `#(G)`5irl parts are there and intact, at least
as far as you can tell.


B for boy, G for girl (in case you didn't catch that):", newPlayer.Name), true, 10);
                input = Input.GetUserInput(" `.").ToLower();
                if (input != "b" && input != "g")
                    InvalidInput();
            }

            newPlayer.Male = input == "b";

            //TODO: later: Add random diary generation here backstory for some random intrinsics.
            //Something like "You pat yourself down and find a small book in your pocket, you pull it out
            //and read..." Bam story here.

            DisplayCharScreenBack();
            Console.CursorTop = 3;
            Out.WriteCenter("`5Quality Assurance", false, true);
            Console.CursorLeft = 6;

            Out.WriteLeftAlignToColumn(
string.Format(@"Looking around you see a plume of dust in the
distance, undoubtedly the cart that dumped you. Just beyond
the plume you see what might possibly be a town. With night fast
approaching and little other option, you make your way towards
the distant blot.

Some time later, as you approach the town gate (if you can even
call THIS a town) one of the guards steps forth thrusting a
yellowed parchment in your direction, saying 'Ayyyy, 'old on
just a minute there ragamuffin, the Mayor says I'm to give this
'ere QA form to any seeking entry, reason bring 'cuz we don't 
want no scrubs. You take the parchment and look it over...

"),true, 10);

            input = Input.GetUserInput("(Psssst.... Hit enter now.)");

            //TODO: Allot starting stats.

            //TODO: Pick qualifying skills and set their levels.

            //All done time to play  the game.

            
            
            return newPlayer;
        }

        static void DisplayCharScreen(Player player, bool modify, bool first)
        {
            CharacterPage CurrentPage=CharacterPage.Main;
            bool Quit = false;
            string Options = "[M]ain [A]ctive [P]assive [I]nventory [S]pells";
            DisplayCharScreenBack();


            while (!Quit)
            {
                switch (CurrentPage)
                {
                    case CharacterPage.Main:
                        break;
                    case CharacterPage.ActiveSkill:
                        break;
                    case CharacterPage.PassiveSkill:
                        break;
                    case CharacterPage.Inventory:
                        break;
                    case CharacterPage.Spells:
                        break;
                }
            }

        }

        public void ResetCursor()
        {
            Console.CursorTop = 3;
            Console.CursorLeft = 6;
        }

        static void DisplayCharScreenBack()
        {
            Console.Clear();
            System.IO.StreamReader SR = new StreamReader("./Assets/CharacterScreen.txt");
            Console.Write(SR.ReadToEnd());
            SR.Close();
        }
        #endregion
    }
}
