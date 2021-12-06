using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    public class Podcast
    {
        private SaveData SaveData { get; set; }

        public Podcast(SaveData saveData)
        {
            SaveData = saveData;
        }

        public void PodcastIntro()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("'... You're listening to True Crime Hang Time with Seb and Abby, and today we're talking about ");
            Console.WriteLine(PodcastDialogue());
            Console.ForegroundColor = ConsoleColor.White;
        }       

        string PodcastDialogue()
        {
            switch (SaveData.DayCount)
            {
                case 0:
                    return "Ed Kemper. Did you know he narrated audiobooks while he was in prison? I know, wild right?\nImagine your kids listening to a serial killer telling them bedtime stories. Creepy...'";
                case 1:
                    return "BTK. Not content with murdering ten different people, he decided it would be a good idea to taunt the police about the fact that \nthey never caught him. Of course, this later led to his arrest and incarceration. Good one, genius...'";
                case 2: 
                    return "the one and only Ted Bundy. We can't do a murder podcast without talking about Ted, can we? \nThis is going to be a long one folks, so put the kettle on, settle in, and prepare yourselves...'";
                case 3:
                    return "two killers from accross the pond - Ian Brady and Myra Hindley. \nDuring the sixties they murdered five children, and kept photos and audio of their actions...'";
                case 4:
                    return "Ed Gein. The real life inspiration for Buffalo Bill in the thriller Silence of the Lambs, \nGein was known to exhume bodies and use them to fashion keepsakes, including clothing...'";
                case 5:
                    return "John Wayne Gacy. Gacy kept the bodies of his victims in the crawlspace underneath his house. \nAll thirty three of them...'";
                case 6:
                    return "Pedro Lopez. Despite confessing to the murder of more than three HUNDRED people, \nhe was released from prison in 1998, and his current whereabouts are unknown...'";
                default:
                    if (SaveData.HotShot == true)
                    {
                        return $"{SaveData.TheMurderer}, the Pelican Town Murderer. We're here to give you the inside scoop on this one, \nas it happened right under our noses. Stay tuned for the full details...'";
                    }
                    else return $"the Pelican Town Murderer. Despite the best efforts of Detective {SaveData.PlayerName}, their identity has not yet been discovered, and is likely to remain a mystery...";
            }
        }
    }
}
