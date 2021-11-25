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
                     
            while (true)
            {
                if (SaveData.AbigailCount == 0)
                {
                    //first meeting with Abigail
                    Console.WriteLine("Abigail > Oh that's right...I heard someone was coming to investigate...");
                    Console.WriteLine("Abigail > It's kind of a shame, really. I was hoping to solve the mystery myself.");
                    SaveData.AbigailCount++;
                }
                else
                {

                    Random dialogue = new();
                    int random = dialogue.Next(0, 9);

                    switch (random) // generic chat
                    {
                        case 0: Console.WriteLine("Abigail > Oh, hey. Taking a break from work?"); break;
                        case 1: Console.WriteLine("Abigail > Oh, hi! Do you ever hang out at the cemetery? It's a peaceful place to spend some time alone."); break;
                        case 2: Console.WriteLine("Abigail > I'm not in a good mood right now... what do you want?"); break;
                        case 3:
                            Console.WriteLine("Abigail > ...*sigh*... I know my parents mean well, but sometimes they just cannot understand my point of view.");
                            Console.WriteLine("Abigail > Weren't they ever young?"); break;
                        case 4: Console.WriteLine("Abigail > Hey. Sorry in advance if I say anything rude. I didn't get much sleep last night. What do you want?"); break;
                        case 5: Console.WriteLine("Abigail > Oh no, I think my Dad's going to cook dinner tonight... I don't feel like doing anything today..."); break;
                        case 6: Console.WriteLine("Abigail > The fresh mountain air is nice on a day like this. I wonder if the frogs will make an appearance soon."); break;
                        case 7:
                            Console.WriteLine("Abigail > Oh, hi Detective " + SaveData.PlayerName + ". Taking a break from your work? Me too. Oh! Nothing physical... ");
                            Console.WriteLine("just some online classes I'm taking."); break;
                        case 8: Console.WriteLine("Abigail > Hi, I'm glad to see you. I want to take my mind off things for a while... how is your day going?"); break;
                        default: break;
                    }
                }
                ChooseNPC chat = new();
                chat.ChatOptions();

                var choice = Console.ReadLine();

                if (choice == "L")
                {
                    Console.WriteLine("Me > It was nice to see you Abby. Talk soon!");
                    break;
                }

                switch (choice)
                {
                    case "C":
                        Console.WriteLine("Hi Abigail, just wanted to see how you're doing.");
                        SaveData.AbigailFriendship++;
                        break;
                    case "G":
                        Console.WriteLine("Oh here, I wanted to give you this.");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("I was hoping I could ask you about Mayor Lewis?");
                        Console.WriteLine("Abigail > Oh, sure. What about him?");
                        Investigate();
                        Console.WriteLine("Ok, I think I've got what I need. Thanks, Abigail.");
                        break;
                    default: break;
                }
            }
                       
        }
        public override void Gift()
        {
            string NPCName = "Abigail";
            var FavGift = Enums.Items.Amethyst;
            var DislikedGift = Enums.Items.Horseradish;
            string LoveGift = "Hey, how’d you know I was hungry? This looks delicious!";
            string HateGift = "What am I supposed to do with this?";
            string NeutralGift = "You brought me a present? Thanks.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            int friendshipChange = giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            SaveData.AbigailFriendship += friendshipChange;
        }

        bool caseH { get; set; }
        bool caseW { get; set; }
        bool caseP { get; set; }
        bool caseS { get; set; }

        void Investigate() // Questioning about the murder
        {
            while (true)
            {
                if (caseH == true && caseW == true && caseP == true && caseS == true)
                {
                    break;
                }

                Console.WriteLine("");
                Console.WriteLine("H > How well did you know him?");
                Console.WriteLine("W > Where were you on the night he was murdered?");
                if (SaveData.PierreLied == true)
                {
                    Console.WriteLine("P > Was Pierre home with you?");
                }
                SaveData.MyInventory.TryGetValue(Enums.Items.LewisStatue, out int lewisStatue);
                if (lewisStatue > 0)
                {
                    Console.WriteLine("S > Have you ever seen this statue before?");
                }
                Console.WriteLine("L > Leave");

                var askAbigail = Console.ReadLine();
                if (askAbigail == "L")
                {
                    return;
                }

                else switch (askAbigail)
                {
                    case "H":
                            Console.WriteLine("How well did you know him?");                          
                            break;
                    case "W":
                            Console.WriteLine("Where were you on the night he was murdered?");                       
                            break;
                    case "P":
                        if (SaveData.PierreLied == true)
                            Console.WriteLine("Abigail > Yeah, we were playing Journey of the Prairie King together.");                            
                        if (SaveData.AbigailFriendship > 4)
                            Console.WriteLine("Abigail pauses.");
                            Console.WriteLine("Abigail > Well… um, that wasn't true about my dad being home actually.");
                            Console.WriteLine("I was playing Journey of the Prairie King, but he wasn't there. He only got home about midnight. ");
                            break;
                    case "S":
                        if (lewisStatue > 0) Console.WriteLine("Abigail > Let's see. No, I don't think so. Ha, it looks like Lewis, that's funny.");                       
                            break;
                        case "L": 
                            break;
                    default: break;
                }
            }
        }

    }
}
