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
            SaveData.LastChat = "Wizard";

            if (SaveData.WizardCount == 0) //first meeting
            {
                Console.WriteLine($"Wizard > Ah, yes. I have predicted your arrival a long time ago, young {SaveData.PlayerName}. However, your fate is ultimately in your own hands.");
                SaveData.WizardCount++;
            }

            else
            {
                while (true)
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
                    //player dialogue options
                    Console.WriteLine(""); //chat
                    Console.WriteLine(""); //gift
                    Console.WriteLine(""); //investigate
                    Console.WriteLine(""); //Leave

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
                        case "L": return;
                        default: break;
                    }

                    SaveData.WizardCount++;
                }
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give the Wizard?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "Fav" && Enums.Items.VoidEssence > 0)
            {
                Console.WriteLine("Wizard > Ahh, this is imbued with potent arcane energies. It's very useful for my studies. Thank you!"); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.VoidEssence, out var voidEssenceCount);
                voidEssenceCount--;
                SaveData.MyInventory[Enums.Items.VoidEssence] = voidEssenceCount;
            }

            else if (gift == "hate" && Enums.Items.RedMushroom > 0)
            {
                Console.WriteLine("Wizard > Ughh... These are utterly mundane. Please refrain from bothering me with this in the future."); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.RedMushroom, out var redMushroomCount);
                redMushroomCount--;
                SaveData.MyInventory[Enums.Items.Horseradish] = redMushroomCount;
            }
            else //neutral
            {
                Console.WriteLine("Wizard > Thank you, this will prove useful, I think.");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }
    }
}
