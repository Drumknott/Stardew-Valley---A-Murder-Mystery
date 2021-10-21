using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Penny : NPC
    {
        private SaveData SaveData { get; set; }

        public Penny(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            SaveData.LastChat = "Penny";

            if (SaveData.PennyCount == 0) //first meeting
            {
                Console.WriteLine("Penny > Hi... Oh, did you want something?");
                SaveData.PennyCount++;
            }

            else
            {
                while (true)
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 12);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Penny > I'm eager to move out. It's such a burden to be worrying about Mom all the time."); 
                            Console.WriteLine("I want her to be happy, but I can't stay here forever... you know?"); break;
                        case 1: Console.WriteLine("Penny > I'm tutoring Vincent and Jas today... They're a handful, but it's nice to make a difference in someone's life."); break;
                        case 2: Console.WriteLine("Penny > We don't have a school here but I'm doing my best to give Vincent and Jas a proper education. Every child deserves a chance to be successful.");
                            Console.WriteLine("Jas is very good at math and reading. Vincent is good at... well, he has an active imagination"); break;
                        case 3: Console.WriteLine("Penny > You know what? I should take the children on a field trip some time. Maybe to the forest. A guest speaker would be nice...");
                            Console.WriteLine("Penny >maybe someone familiar with nature? Sorry, I'm just thinking out loud."); break;
                        case 4: Console.WriteLine("Penny > I've lived in Pelican Town my whole life. Can you believe that? I guess there's a lot out there I'll never experience."); break;
                        case 5: Console.WriteLine("Penny > We're very lucky to have a library in such a small town. When you're lost in a book, it's easy to forget the realities of your life.");
                            Console.WriteLine("Penny > ...Maybe that's why I like reading so much. ...Sorry. I got carried away there."); break;
                        case 6: Console.WriteLine("Penny > If you dig in the dirt you can find some interesting things. One time I found a really old piece of pottery.");
                            Console.WriteLine("Penny > I brought it to Gunther and he said it was over a thousand years old."); break;
                        case 7: Console.WriteLine("Penny > Dishes, dishes, dishes. Ugh... If my mother wasn't always nursing a headache from her late nights at the saloon, maybe she could help around the house a little."); break;
                        case 8: Console.WriteLine("Penny > This is such a small town. You can't avoid meeting everyone. I wonder what is like to live in the city?"); break;
                        case 9: Console.WriteLine("Penny > Hello. Ummm... The weather's interesting today, don't you think? Sorry..."); break;
                        case 10: Console.WriteLine("Penny > I've been trying to keep our place clean, but it always gets messy again. It's hard to run a household all by yourself."); break;
                        case 11: Console.WriteLine("Penny > Things changed a lot after the JojaMart went up. It's been really bad for Pierre's shop.");
                            Console.WriteLine("Penny > Mom loves JojaMart, though. The prices are cheap, so she can afford a lot more there than she ever could at Pierre's."); break;
                        case 12: Console.WriteLine("Penny > The raindrops are really loud on the metal roof of our trailer. It's soothing, though."); break;
                        default: break;
                    }
                    //player dialogue options
                    Console.WriteLine(""); //chat
                    Console.WriteLine(""); //gift
                    Console.WriteLine(""); //investigate
                    Console.WriteLine("L > Leave");

                    var dialogue1 = Console.ReadLine();

                    switch (dialogue1)
                    {
                        case "chat":
                            Console.WriteLine("");
                            SaveData.PennyFriendship++;
                            break;
                        case "gift":
                            Console.WriteLine("");
                            Gift();
                            break;
                        case "investigate":
                            Console.WriteLine("");
                            Investigate();
                            break;
                        case "L": SaveData.PennyCount++;
                            return;
                        default: break;
                    }

                    
                }
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Penny?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "Diamond" && Enums.Items.Diamond> 0)
            {
                Console.WriteLine("Penny > Thank you! I really love this!"); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.PennyFriendship += 2;

                SaveData.MyInventory.TryGetValue(Enums.Items.Diamond, out var diamondCount);
                diamondCount--;
                SaveData.MyInventory[Enums.Items.Diamond] = diamondCount;
            }

            else if (gift == "Beer" && Enums.Items.Beer> 0)
            {
                Console.WriteLine("Penny > Ugh...I'm sorry, but I absolutely hate this."); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.PennyFriendship--;

                SaveData.MyInventory.TryGetValue(Enums.Items.Beer, out var beerCount);
                beerCount--;
                SaveData.MyInventory[Enums.Items.Beer] = beerCount;
            }
            else //neutral
            {
                Console.WriteLine("Penny > Thanks, this looks nice.");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }
    }
}
