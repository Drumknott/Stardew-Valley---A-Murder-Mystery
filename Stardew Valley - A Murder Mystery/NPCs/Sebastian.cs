using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Sebastian : NPC
    {
        private SaveData SaveData { get; set; }

        public Sebastian(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Sebastian";

                if (SaveData.SebastianCount == 0) //first meeting
                {
                    Console.WriteLine("Sebastian > Oh. You just moved in, right? Cool.");
                    Console.WriteLine("Out of all the places you could live, you chose Pelican Town ? ");
                    SaveData.SebastianCount++;
                }

                else
                {

                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Sebastian > Um... need something?"); break;
                        case 1: Console.WriteLine("Sebastian > If I just disappeared would it really matter?"); break;
                        case 2: Console.WriteLine("Sebastian > I was thinking... people are like stones skipping over the water. Eventually we're going to sink."); break;
                        case 3: Console.WriteLine("Sebastian > What am I going to do today? Probably nothing."); break;
                        case 4: Console.WriteLine("Sebastian > Sam is probably my only friend in this town. Well, Abby is nice too, but...Umm.. nevermind."); break;
                        case 5: Console.WriteLine("Sebastian > I snuck into the caves last night and got a nasty cut from a rock crab. Don't tell anyone, okay?"); break;
                        case 6: Console.WriteLine("Sebastian > Why does everyone like Maru so much? Sure, she's smart and friendly, but don't they realize it's all just an attention-grabbing scam? Sorry..."); break;
                        case 7: Console.WriteLine("Sebastian > Uh... I don't really know you."); break;
                        case 8: Console.WriteLine("Sebastian > What? I didn't hear you... I'm busy thinking about something. What do you want?"); break;
                        case 9: Console.WriteLine("Sebastian > You know, I should be doing something productive right now. I just lose focus too fast... Maybe I should drink more coffee?"); break;
                        case 10: Console.WriteLine("Sebastian > Hey. Your name is " + SaveData.PlayerName + ", right?"); break;
                        case 11: Console.WriteLine("Sebastian > Having a good weekend? ...nice."); break;
                        case 12:
                            Console.WriteLine("Sebastian > I usually stay inside, but I do go to the beach now and then. Pretty much only when it's raining, though. For some reason, staring off into the bleak horizon makes me feel... I dunno.");
                            Console.WriteLine("\tLike it's worthwhile to keep pushing on, I guess.”"); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "chat":
                        Console.WriteLine("Sebastian > Do you like True Crime?\nY> Yes\nN > No");
                        switch (Console.ReadLine())
                        {
                            case "Y": Console.WriteLine("Sebastian > Did you know that you can dissolve the body of a frog in Mountain Dew? I wonder if that would work for a person..."); break;
                            case "N": Console.WriteLine("Sebastian > No? Oh, ok. Kind of weird that you're a cop then.");  break;
                            default: break;
                        }
                        SaveData.SebastianFriendship++;
                        break;
                    case "gift":
                        Console.WriteLine("Hey Sebastian. Would you like this?");
                        Gift();
                        break;
                    case "investigate":
                        Console.WriteLine("Hi Sebastian. Can I ask you some questions about Mayor Lewis?");
                        Investigate();
                        break;
                    case "L":
                        SaveData.SebastianCount++;
                        return;
                    default: break;
                }                
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Sebastian?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "FrozenTear" && Enums.Items.FrozenTear > 0)
            {
                Console.WriteLine("Sebastian > I really love this. How did you know?"); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.SebastianFriendship += 2;

                SaveData.MyInventory.TryGetValue(Enums.Items.FrozenTear, out var frozenTearCount);
                frozenTearCount--;
                SaveData.MyInventory[Enums.Items.FrozenTear] = frozenTearCount;
            }

            else if (gift == "Coal" && Enums.Items.Coal > 0)
            {
                Console.WriteLine("Sebastian > ...I hate this."); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.SebastianFriendship--;

                SaveData.MyInventory.TryGetValue(Enums.Items.Coal, out var coalCount);
                coalCount--;
                SaveData.MyInventory[Enums.Items.Coal] = coalCount;
            }
            else //neutral
            {
                Console.WriteLine("Sebastian > ...thanks.");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {
            //Seb and Abby are starting a true crime podcast, with Sam on production and audio effects.
        }
    }
}
