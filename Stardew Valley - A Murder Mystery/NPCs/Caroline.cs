using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Caroline : NPC
    {
        private SaveData SaveData { get; set; }

        public Caroline(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            {
                SaveData.LastChat = "Caroline";

                if (SaveData.CarolineCount == 0) //first meeting
                {
                    Console.WriteLine("Caroline > Hello! You must be " + SaveData.PlayerName + ", the Detective. I'm Caroline. My husband runs the general store here.");
                    Console.WriteLine("Caroline > And have you met my daughter, Abigail? She's the pale one with the purple hair.");
                    SaveData.CarolineCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 9);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Caroline > I wish Abby wouldn't spend so much time in her room."); break;
                        case 1: Console.WriteLine("Caroline > I've seen wild horseradish in the forest. Foraging can be a fun way to earn some cash. Or you can use what you find as gifts."); break;
                        case 2: Console.WriteLine("Caroline > Hi there. Do you have everything you need for the investigation? If not, we might be able to help you out. We carry a variety of useful items."); break;
                        case 3: Console.WriteLine("Caroline > Hmmm... I wonder if I can get Pierre to cook dinner tonight."); break;
                        case 4: Console.WriteLine("Caroline > Hmmm... what am I going to make for dinner tonight? Maybe I'll just get take-out from the Saloon."); break;
                        case 5: Console.WriteLine("Caroline > It's a fine-looking day. On days like this I like to help Evelyn with the public gardens. She's strong for her age, but I think she appreciates all the help she can get."); break;
                        case 6: Console.WriteLine("Caroline > Is it just me, or does Abigail have an unhealthy interest in doom and gloom? Maybe I'm just too old to understand."); break;
                        case 7: Console.WriteLine("Caroline > Abby's always had a strange interest in the occult. I'm not sure where she gets it from..."); break;
                        case 8: Console.WriteLine("Caroline > Today I'm just going to relax and think positively. Do you ever take a day off?"); break;
                        case 9: Console.WriteLine("Caroline > Vote for Pierre!"); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > Hi Caroline, how are you doing?");
                        Console.WriteLine("Caroline > Not bad, all this campaigning busness is stressful though. Vote for Pierre!");
                        SaveData.CarolineCount++;
                        break;
                    case "G":
                        Console.WriteLine("Me > Hey Caroline, I thought you might like this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > Hi Caroline, I was wondering if I could ask you a few questions about Mayor Lewis?");
                        Investigate();
                        Console.WriteLine("Me > Great. Thanks for your help, Caroline.");
                        break;
                    case "L": SaveData.CarolineCount++;
                        Console.WriteLine("Me > Bye, Caroline!");
                        return;
                    default: break;
                }
            }
        }

        public override void Gift()
        {
            string NPCName = "Caroline";
            var FavGift = Enums.Items.FishTaco;
            var DislikedGift = Enums.Items.Quartz;
            string LoveGift = "You're giving this... to me? I'm speechless.";
            string HateGift = "This is absolute junk. I'm offended.";
            string NeutralGift = "Oh, that's sweet. Thank you.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);        
        }

        void Investigate()
        {
            //mention M. Rasmodius
            bool Case1 = false;
            bool Case2 = false;
            bool Case3 = false;

            Console.WriteLine("Caroline > Oh, of course. I'll help any way I can.\n");

            while (true)
            {
                if (Case1 && Case2 && Case3)
                {
                    Console.WriteLine("Caroline > Oh, Detective? I think I know someone who might be able to help. If you head down to the forst, you'll see a tower out west.");
                    Console.WriteLine("Caroline > Go there, and say Caroline sent you.");
                    SaveData.CarolineSentMe = true;
                    return;
                }

                Console.WriteLine("W > Where were you the night he was killed?");
                Console.WriteLine("H > How is Pierre feeling about the election?");
                Console.WriteLine("D > Do you know if there was anyone who might want to harm Lewis?");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        Console.WriteLine("Caroline > I was at home. Catching up on some of my gossip magazines I think.");
                        Console.WriteLine("Me > And what about Pierre and Abigail?");
                        Console.WriteLine("Caroline > Oh, Abby was playing more of those silly videogames. I wish she would grow up a bit.");
                        Console.WriteLine("Me > And Pierre?");
                        Console.WriteLine("Caroline > I... I think he was doing stock check in the shop?");
                        Console.WriteLine("Me > You're sure?");
                        Console.WriteLine("Caroline > Well he wasn't in the house so can't think where else he'd be. Don't worry Detective, he would never harm a fly.");
                        Case1 = true;
                        break;
                    case "H":
                        Console.WriteLine("Caroline > He's a bit stressed about it, I think. That's to be expected though. He's worried that Morris might win and the shop will go out of business.");
                        if (SaveData.CrypticNote == true)
                        {
                            Console.WriteLine("Me > Do you think he's running for Mayor to stop that from happening? To stop Morris from winning?");
                            Console.WriteLine("Caroline > It's definitely a big factor, yes. What does this have to do with Lewis, though?");
                            Console.WriteLine("Me > I'm just trying to establish what lengths Pierre would go to to protect his business.");
                            Console.WriteLine("Caroline > ...");
                        }
                        Case2 = true;
                        break;
                    case "D":
                        Console.WriteLine("Caroline > Not harm him, no. I know Demetrius had some disagreements with him about what the town was doing to protect the local ecosystem, \nbut it was never serious enough to lead to violence.");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
