using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Pierre : NPC
    {
        private SaveData SaveData { get; set; }

        public Pierre(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Pierre";

                if (SaveData.PierreCount == 0) //first meeting
                {
                    Console.WriteLine($"Pierre > Hey, it's Detective {SaveData.PlayerName}! I'm Pierre, owner of the local general store.");
                    Console.WriteLine("Pierre > A little mystery like this could really inject life into the local economy!");
                    SaveData.PierreCount++;
                }

                else
                {

                    if (SaveData.DayCount == 1) //aerobics day
                    {
                        Console.WriteLine("Pierre > The girls are doing their aerobics back there. I wouldn't disturb them if I was you, it's not a pretty sight.");
                    }

                    else
                    {
                        Random dialogue = new();
                        int random = dialogue.Next(0, 9);

                        switch (random) //random dialogue
                        {
                            case 0: Console.WriteLine("Pierre > Welcome! If you're looking for seeds, you've come to the right place!"); break;
                            case 1: Console.WriteLine($"Pierre > Hi, {SaveData.PlayerName}. Need any seeds or fruit tree saplings?"); break;
                            case 2: Console.WriteLine("Pierre > Sometimes I get new items in stock, so make sure to stop by every so often. It's a lot of work to run a shop."); break;
                            case 3: Console.WriteLine("Pierre > I'm happy to buy any produce off you. I'll give you a fair price, of course!"); break;
                            case 4: Console.WriteLine($"Pierre > I really do appreciate your business, Detective {SaveData.PlayerName}. I've been having a harder and harder time turning a decent profit."); break;
                            case 5: Console.WriteLine("Pierre > Business has been slow since Joja moved into town. It's hard to compete with their selection."); break;
                            case 6: Console.WriteLine("Pierre > *sigh*... I've got those behind-the-counter blues... I wish I could go for a walk, but I can't leave the store unattended. I've heard the flowers are in bloom and the air smells great..."); break;
                            case 7: Console.WriteLine($"Pierre > Hey, {SaveData.PlayerName}. You're my number one customer!"); break;
                            case 8: Console.WriteLine("Pierre > Vote for Pierre!"); break;
                            case 9: Console.WriteLine("Pierre > Remember, a vote for Pierre is a vote against Joja Mart! Let's save our community!"); break;
                            default: break;
                        }
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > Hi Pierre, how are you?");
                        break;
                    case "G":
                        Console.WriteLine("Me > Would you like this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > Can I borrow you for a few minutes?");
                        Investigate();
                        break;                 
                    case "L":
                        SaveData.PierreCount++;
                        return;
                    default: break;
                }                                  
            }            
        }

        public override void Gift()
        {
            string NPCName = "Pierre";
            var FavGift = Enums.Items.FriedCalamari;
            var DislikedGift = Enums.Items.Corn;
            string LoveGift = "This is my all-time favorite! Thank you!";
            string HateGift = "Please, never bring this to me again.";
            string NeutralGift = "A present? Thanks!";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift == "JojaCola" && Enums.Items.JojaCola > 0)
            {
                Console.WriteLine("Pierre > Is this some kind of sick joke? Why would you bring me my competitor's product?");
                Console.WriteLine(gift + " removed from Inventory.");

                SaveData.MyInventory.TryGetValue(Enums.Items.JojaCola, out var jojaColaCount);
                jojaColaCount--;
                SaveData.MyInventory[Enums.Items.JojaCola] = jojaColaCount;
            }

            else if (gift == "MapleBar" && Enums.Items.MapleBar > 0)
            {
                Console.WriteLine("Pierre > Ooh, a maple bar. Thanks, I love these!");
                Console.WriteLine(gift + " removed from Inventory.");

                SaveData.MyInventory.TryGetValue(Enums.Items.MapleBar, out var mapleBarCount);
                mapleBarCount--;
                SaveData.MyInventory[Enums.Items.MapleBar] = mapleBarCount;

                if (SaveData.StealFromPierre == true)
                {
                    SaveData.FuckYouPierre = true;
                }
            }
            else
            {
                Gift giftMethod = new(SaveData);
                giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            }          
        }

        void Investigate()
        {
            bool Case1 = false;
            bool Case2 = false;
            bool Case3 = false;
            bool Case4 = false;

            if (SaveData.TheMurderer == "Pierre")
            {
                Console.WriteLine("Pierre > I'm a bit busy right now Detective, could we do this later?\n");
                Console.WriteLine("Y > Sure, I'll come another time");
                Console.WriteLine("N > This is important Pierre. It won't take long.");

                if (Console.ReadLine().Substring(0, 1).ToUpper() == "Y") return;
            }
            else Console.WriteLine("Pierre > Of course Detective. What can I help with?");

            while (true)
            {
                if (Case1 && Case2 && Case3 && Case4) return;

                Console.WriteLine("W > Where were you the night Mayor Lewis was attcked?");
                Console.WriteLine("M > Did you like Lewis?");
                if (SaveData.CrypticNote) Console.WriteLine("N > Did you write this note?");
                if (SaveData.Blackmail == true) Console.WriteLine("D > Demetrius says you blackmailed him.");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        if (SaveData.TheMurderer == "Pierre")
                        {
                            Console.WriteLine("Pierre > I was at home. I was playing one of Abby's videogames with her.");
                            Console.WriteLine("Pierre > Prarie Prince, or somthing like that.");
                            SaveData.PierreLied = true;
                        }
                        else
                        {
                            Console.WriteLine("Pierre > I went down to the beach for a walk. It's lovely down there in the evenings.");
                        }
                        Case1 = true;
                        break;
                    case "M":
                        Console.WriteLine("Pierre > No. Not if I'm honest. He wasn't interested in protecting small local businesses like mine.");
                        Console.WriteLine("Pierre > He was more interested in getting handouts from big corporations like Joja Mart.");
                        Console.WriteLine("Me > Handouts?");
                        Console.WriteLine("Pierre > Yes! These big corporations think they can just throw money at problems and then they can do whatever they want.");
                        Console.WriteLine("Me > Are you saying Lewis was accepting bribes from Joja Mart? Do you have any proof of that?");
                        Console.WriteLine("Pierre > No, I don't have any proof. Morris told me, but he was careful not to say anything specific.");
                        Case2 = true;
                        break;
                    case "N" when (SaveData.CrypticNote):
                        Console.WriteLine("Pierre's eyes widen.");
                        Console.WriteLine("Pierre > This is it! This is proof that Joja was paying him off! Don't you see?");
                        Console.WriteLine("Me > You're saying this is from Joja Mart?");
                        Console.WriteLine("Pierre > One million percent. I'd bet my store Morris wrote this.");
                        Case3 = true;
                        break;
                    case "D" when (SaveData.Blackmail):
                        Console.WriteLine("Pierre looks nervous.");
                        Console.WriteLine("Pierre > Um, what? No. Why would I do that?");
                        Console.WriteLine("Me > He says you gave him this blood covered statue of Lewis and asked him to hide it on the night Lewis was murdered.");
                        Console.WriteLine("Me > Now, where did you get it from? Did you kill him?");
                        Console.WriteLine("Pierre > Absoloutely not. No. I've never seen that before in my life.");
                        Console.WriteLine("Pierre > Demetrius must be lying. I bet it was him! He must have done it!");
                        Console.WriteLine("Me > What do you have on Demetrius, Pierre? What did you say to threaten him?");
                        Console.WriteLine("Pierre > I didn't. I didn't kill Lewis, and I didn't blackmail Demetrius. I refuse to say anything more.");
                        Case4 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
