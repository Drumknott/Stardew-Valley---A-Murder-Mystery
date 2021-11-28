using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class StardropSaloon : Location
    {
        private SaveData SaveData { get; set; }

        public StardropSaloon(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {    
            Console.WriteLine("You are in the Stardrop Saloon.\n");

            switch (SaveData.DayCount)
            {
                case 0:
                    Console.WriteLine("A friendly looking man behind the bar greets you.");
                    SaveData.npc1 = "Gus";
                    SaveData.npc2 = "Emily";
                    break;
                case 1:
                case 3:
                    Console.WriteLine("Gus greets you from behind the bar.\nGus > How are you doing today Detective?");
                    SaveData.npc1 = "Gus";
                    break;
                case 2:
                    Console.WriteLine("Gus and Emily are behind the bar, but the saloon is otherwise empty.");
                    SaveData.npc1 = "Gus";
                    SaveData.npc2 = "Emily";
                    break;               
                case 4:
                    Console.WriteLine("The Saloon is packed - Gus and Emily seem run off their feet while they try to cater to what seems like half the town.");
                    Console.WriteLine("Abigail, Sebastian and Sam are in the corner by the pool table.");
                    Console.WriteLine("Leah and Elliott are sitting close together at a table.");
                    Console.WriteLine("Pam is at the end of the bar chatting to Gus when he isn't busy.");
                    Console.WriteLine("Robin and Demetrius are sitting together but not talking. She seems annoyed about something.");
                    Console.WriteLine("Pierre and willy chat by the bar, while Shane drinks alone by the jukebox.");
                    SaveData.npc1 = "Gus";
                    SaveData.npc2 = "Emily";
                    SaveData.npc3 = "Abigail";
                    SaveData.npc4 = "Demetrius";
                    SaveData.npc5 = "Elliott";
                    SaveData.npc6 = "Leah";
                    SaveData.npc7 = "Pam";
                    SaveData.npc8 = "Pierre";
                    SaveData.npc9 = "Robin";
                    SaveData.npc10 = "Sam";
                    SaveData.npc11 = "Sebastian";
                    SaveData.npc12 = "Shane";
                    SaveData.npc13 = "Willy";
                    break;
                case 5:
                    SaveData.npc1 = "Leah";
                    SaveData.npc2 = "Elliott";
                    break;
                case 6:
                    
                    break;
                default: break;
            }           
        }

        public override void Forage()
        {
            Console.WriteLine("You can't forage in here.");
        }        
    }
}
