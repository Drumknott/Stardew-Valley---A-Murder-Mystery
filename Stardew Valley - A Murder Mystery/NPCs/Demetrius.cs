using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Demetrius : NPC
    {
        private SaveData SaveData { get; set; }

        public Demetrius(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            {

                SaveData.LastChat = "Demetrius";

                if (SaveData.DemetriusCount == 0) //first meeting
                {
                    Console.WriteLine("Demetrius > Greetings! I'm Demetrius, local scientist and father. Thanks for introducing yourself!");
                    Console.WriteLine("Demetrius > I'm studying the local plants and animals from my home laboratory. Have you met my daughter Maru? She's interested to meet you.");
                    SaveData.DemetriusCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 6);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Demetrius > Maru helps me out in the lab sometimes... She's a good kid."); break;
                        case 1: Console.WriteLine("Demetrius > This valley has a very vibrant and diverse ecosystem. That's one reason I was excited to move here."); break;
                        case 2: Console.WriteLine("Demetrius > There's probably a lot of interesting plants on the farm, huh? Maybe I'll stop by some day and check it out."); break;
                        case 3: Console.WriteLine("Demetrius > Robin has a hot temper. It's better to stay on her good side. Don't tell her I said that."); break;
                        case 4: Console.WriteLine("Demetrius > Let's see... If compounds in the rhizosphere contain sufficient levels of Carbon-13, then... Oh! Sorry. I was pondering some data and I didn't notice you there. Do you need anything?"); break;
                        case 5: Console.WriteLine("Demetrius > It's good to take a break from work every now and then. I guess that's kind of difficult when you're a Detective, though."); break;
                        case 6: Console.WriteLine("Demetrius > Thanks for stopping by. I need to think about something other than legumes for a while. So, what have you been doing lately? That sounds interesting."); break;
                        default: break;
                    }
                }

                Console.WriteLine("");
                Console.WriteLine(""); //chat
                Console.WriteLine(""); //gift
                Console.WriteLine(""); //investigate
                Console.WriteLine("L > Leave");

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "chat":
                        Console.WriteLine("");
                        break;
                    case "gift":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "investigate":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    case "L": SaveData.DemetriusCount++;
                        return;
                    default: break;
                }
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Demetrius?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "BeanHotpot" && Enums.Items.BeanHotpot > 0)
            {
                Console.WriteLine("Demetrius > You're giving this to me? This is amazing!"); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.BeanHotpot, out var beanHotpotCount);
                beanHotpotCount--;
                SaveData.MyInventory[Enums.Items.BeanHotpot] = beanHotpotCount;
            }

            else if (gift == "Quartz" && Enums.Items.Quartz > 0)
            {
                Console.WriteLine("Demetrius > This is disgusting."); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.Quartz, out var quartzCount);
                quartzCount--;
                SaveData.MyInventory[Enums.Items.Horseradish] = quartzCount;
            }
            else //neutral
            {
                Console.WriteLine("Demetrius > Thank you! This is a very interesting specimen.");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate() //if Pierre's the murderer, Demetrius is an accomplice
        {

        }
    }
}
