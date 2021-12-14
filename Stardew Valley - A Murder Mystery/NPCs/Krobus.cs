using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Krobus : NPC //MAH MAIN MAN
    {
        private SaveData SaveData { get; set; }

        public Krobus(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Krobus";

                if (SaveData.KrobusCount == 0) //first meeting
                {
                    Console.WriteLine("Krobus > A human visitor? This is most unusual... I'm Krobus, merchant of rare and exotic goods.");
                    SaveData.KrobusCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 8);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Krobus > ...Have you encountered others like me, in the mines? I'm sorry if they were hostile towards you. You see, we've learned to fear humans...");
                            Console.WriteLine("there have been too many... unpleasant encounters. You haven't... slain any of my friends, have you?"); break;
                        case 1: Console.WriteLine("Krobus > I find things here and I sell them. Care to buy anything?"); break;
                        case 2: Console.WriteLine("Krobus > Please don't tell anyone about me. Humans tend to destroy things they can't understand."); break;
                        case 3: Console.WriteLine("Krobus > I am too sensitive to sunlight to go out on most days. The conditions in here are perfect. Care to buy anything?"); break;
                        case 4: Console.WriteLine("Krobus > Please, don't be alarmed. I am different than the others. I've spent a lot of time observing humans. I know you like to shop. Care to see my wares?"); break;
                        case 5: Console.WriteLine("Krobus > Back again? I suppose it does fit into my theory of human behavior."); break;
                        case 6: Console.WriteLine("Krobus > On Fridays I stay silent as a sign of devotion to Yoba."); break;
                        case 7: Console.WriteLine("Krobus > ...Sorry, I'm still a little wary of humans. My shop is still open to you, however."); break;
                        case 8: Console.WriteLine("Krobus > You're not like the other humans, are you?"); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Hi, Krobus!");
                        SaveData.KrobusFriendship++;
                        break;
                    case "G":
                        Console.WriteLine("Would you like this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Hey Krobus, can I ask you some questions?");
                        Investigate();
                        break;
                    case "L": SaveData.KrobusCount++;
                        return;
                    default: break;
                }                
            }
        }

        public override void Gift()
        {
            string NPCName = "Krobus";
            var FavGift = Enums.Items.VoidEgg;
            var DislikedGift = Enums.Items.Seaweed;
            string LoveGift = "This is an amazing gift. For my people it is a great honor to receive something like this.";
            string HateGift = "Oh... Um. I guess I'll accept it.";
            string NeutralGift = "Thank you.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            int friendshipChange = giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            SaveData.KrobusFriendship += friendshipChange;           
        }

        void Investigate()
        {            
            bool Case1 = false;
            bool Case2 = false;
            bool Case3 = false;

            Console.WriteLine("Krobus > But of course. What do you wish to know?");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("A > Are you friendly with any of the townsfolk?");
                Console.WriteLine("D > Do you know who killed Mayor Lewis?");
                Console.WriteLine("I > Is there anything else I should know?");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "A":
                        Console.WriteLine("Krobus > No, I try and keep hidden from most humans. I watch them though. Their lives are... interesting.");
                        Case1 = true;
                        break;
                    case "D":
                        Console.WriteLine("Krobus > I do not. Though I can tell you the lady from the ranch liked to visit his house a lot...");
                        SaveData.MarnieAndLewis = true;
                        Case2 = true;
                        break;
                    case "I":
                        Console.WriteLine("Krobus > You should look in the mine. One can find some very useful things down there.");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
