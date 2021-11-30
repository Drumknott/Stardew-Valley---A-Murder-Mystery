using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Wizard : NPC
    {
        private SaveData SaveData { get; set; }

        public Wizard(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            {
                SaveData.LastChat = "Wizard";

                if (SaveData.WizardCount == 0) //first meeting
                {
                    Console.WriteLine($"Wizard > Ah, yes. I have predicted your arrival a long time ago, young {SaveData.PlayerName}. However, your fate is ultimately in your own hands.");
                    SaveData.WizardCount++;
                }

                else
                {

                    Random dialogue = new();
                    int random = dialogue.Next(0, 7);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine($"Wizard > Ah, yes. I have seen many things about your future, young {SaveData.PlayerName}. If I were to tell you, there could be grave consequences."); break;
                        case 1: Console.WriteLine("Wizard > If you have nothing important to tell me, leave me be. I have much work to do."); break;
                        case 2: Console.WriteLine("Wizard > It takes years of study to understand the language of the elementals. To actually speak their language requires a lifetime of devoted effort. Now, if you'll excuse me..."); break;
                        case 3: Console.WriteLine("Wizard > There are many mysteries around us. You must be patient if you wish to discover them."); break;
                        case 4: Console.WriteLine("Wizard > I believe the townsfolk are afraid of me. It is unfortunate, but I suppose it is human to be afraid of the unknown."); break;
                        case 5: Console.WriteLine("Wizard > Beware, you are standing above a potent magical field. I built my hut right here on purpose, you know."); break;
                        case 6: Console.WriteLine("Wizard > Have you made any headway with the forest spirits?"); break;
                        case 7: Console.WriteLine("Wizard > I sometimes observe the local villagers in secret. I am hoping to find an apprentice. Some day I will leave this mortal plane, but my arcane pursuits must continue."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

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
                    case "L":
                        SaveData.WizardCount++;
                        return;
                    default: break;
                }                
            }
        }

        public override void Gift()
        {
            string NPCName = "Wizard";
            var FavGift = Enums.Items.VoidEssence;
            var DislikedGift = Enums.Items.RedMushroom;
            string LoveGift = "Ahh, this is imbued with potent arcane energies. It's very useful for my studies. Thank you!";
            string HateGift = "Ughh... These are utterly mundane. Please refrain from bothering me with this in the future.";
            string NeutralGift = "Thank you, this will prove useful, I think.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
        }

        void Investigate()
        {

        }
    }
}
