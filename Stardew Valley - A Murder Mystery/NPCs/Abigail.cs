using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Abigail : NPC
    {
        private SaveData SaveData { get; set; }

        public Abigail(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            SaveData.LastChat = "Abigail";

            if (SaveData.AbigailCount == 0)
            {
                //first meeting with Abigail
                Console.WriteLine("Abigail > Oh that's right...I heard someone was coming to investigate...");
                Console.WriteLine("Abigail > It's kind of a shame, really. I was hoping to solve the mystery myself.");
                SaveData.AbigailCount += 1;
            }

            if (SaveData.AbigailCount > 0)
            {
                Random dialogue = new();
                int random = dialogue.Next(0, 9);

                switch (random)
                {
                    case 0: Console.WriteLine("Abigail > Oh, hey. Taking a break from work?"); break;
                    case 1: Console.WriteLine("Abigail > Oh, hi! Do you ever hang out at the cemetery? It's a peaceful place to spend some time alone."); break;
                    case 2: Console.WriteLine("Abigail > I'm not in a good mood right now... what do you want?"); break;
                    case 3: Console.WriteLine("Abigail > ...*sigh*... I know my parents mean well, but sometimes they just cannot understand my point of view.");
                            Console.WriteLine("Weren't they ever young?"); break;
                    case 4: Console.WriteLine("Abigail > Hey. Sorry in advance if I say anything rude. I didn't get much sleep last night. What do you want?"); break;
                    case 5: Console.WriteLine("Abigail > Oh no, I think my Dad's going to cook dinner tonight... I don't feel like doing anything today..."); break;
                    case 6: Console.WriteLine("Abigail > The fresh mountain air is nice on a day like this. I wonder if the frogs will make an appearance soon."); break;
                    case 7: Console.WriteLine("Abigail > Oh, hi Detective " + SaveData.PlayerName + ". Taking a break from your work? Me too. Oh! Nothing physical... ");
                            Console.WriteLine("just some online classes I'm taking."); break;
                    case 8: Console.WriteLine("Abigail > Hi, I'm glad to see you. I want to take my mind off things for a while... how is your day going?"); break;
                    default: break;
                }

                Console.WriteLine("H > Just wanted to say Hi.");
                Console.WriteLine("G > Here, I have something for you (Gift)");
                Console.WriteLine("M > I was hoping I could ask you about the murder?");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "H": Console.WriteLine("Hi Abigail, just wanted to see how you're doing.");
                        SaveData.AbigailFriendship++;
                        break;
                    case "G": Console.WriteLine("Oh here, I wanted to give you this.");
                        Gift();
                        break;
                    case "M": Console.WriteLine("I was hoping I could ask you about Mayor Lewis?");
                        Console.WriteLine("Abigail > Oh, sure. What about him?");

                        while (SaveData.AbigailInvestigated <5)
                        {
                            Console.WriteLine("H > How well did you know him?");
                            Console.WriteLine("W > Where were you on the night he was murdered?");
                            if (SaveData.PierreLied == true)
                            {
                                Console.WriteLine("P > Was Pierre home with you?");
                            }
                            SaveData.MyInventory.TryGetValue(Enums.Items.LewisStatue, out int lewisStatue);
                            if (lewisStatue >0)
                            {
                                Console.WriteLine("S > Have you ever seen this statue before?");
                            }

                            var askAbigail = Console.ReadLine();

                            switch (askAbigail)
                            {
                                case "H": Console.WriteLine("");
                                    SaveData.AbigailInvestigated++;
                                    break;
                                case "W": Console.WriteLine("");
                                    SaveData.AbigailInvestigated++;
                                    break;
                                case "P": if (SaveData.PierreLied == true) 
                                        Console.WriteLine("Abigail > Yeah, we were playing Journey of the Prairie King together.");
                                    SaveData.AbigailInvestigated++;
                                    if (SaveData.AbigailFriendship > 4)
                                        Console.WriteLine("Abigail pauses.");
                                        Console.WriteLine("Abigail > Well… um, that wasn't true about my dad being home actually."); 
                                        Console.WriteLine("I was playing Journey of the Prairie King, but he wasn't there. He only got home about midnight. ");
                                        break;
                                case "S": if (lewisStatue >0) Console.WriteLine("");
                                    SaveData.AbigailInvestigated++;
                                    break;
                                default: break;
                            }
                        }
                        Console.WriteLine("Ok, I think I've got what I need. Thanks, Abigail.");
                        break;
                    default: break;
                }

            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Abigail?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            {
                if (gift == "Amethyst" && Enums.Items.Amethyst >0)
                {
                    Console.WriteLine("Abigail > Hey, how’d you know I was hungry? This looks delicious!"); // Abi loves
                    SaveData.AbigailFriendship +=2;

                    SaveData.MyInventory.TryGetValue(Enums.Items.Amethyst, out var amethystCount);
                    amethystCount--;
                    SaveData.MyInventory[Enums.Items.Amethyst] = amethystCount;
                }

                if (gift == "Horseradish" && Enums.Items.Horseradish > 0)
                {
                    Console.WriteLine("Abigail > What am I supposed to do with this ?"); //Abi hates
                    SaveData.AbigailFriendship --;

                    SaveData.MyInventory.TryGetValue(Enums.Items.Horseradish, out var horseradishCount);
                    horseradishCount--;
                    SaveData.MyInventory[Enums.Items.Horseradish] = horseradishCount;
                }
                //else if [neutral gift]
                    
            }

            Console.WriteLine("Abigail > You brought me a present ? Thanks."); //Abi neutral
            

        }

    }
}
