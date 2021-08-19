using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Shane : NPC
    {
        private SaveData SaveData { get; set; }
        bool caseW { get; set; }
        bool caseH { get; set; }
        bool caseM { get; set; }

        public Shane(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            SaveData.LastChat = "Shane";

            if (SaveData.ShaneFriendship >1)
            {
                while (true)
                {
                    if (caseH == true && caseM == true && caseW == true) break;

                    Console.WriteLine("W > What were you doing the evening Mayor Lewis was found dead?");
                    Console.WriteLine("H > How well did you know Mayor Lewis?");
                    Console.WriteLine("M > You live with Marnie? Can you tell me about her relationship with Mayor Lewis?");
                    Console.WriteLine("L > Leave");
                    Console.WriteLine("");
                    var question = Console.ReadLine();
                    switch (question)
                    {
                        case "W":
                            Console.WriteLine("Me > What were you doing the evening Mayor Lewis was found dead?");
                            Console.WriteLine("Shane > I'd had a busy day at work, you know? So I was just chilling at home with a few beers.");
                            caseW = true;
                            break;
                        case "H":
                            Console.WriteLine("Me > How well did you know Mayor Lewis?");
                            Console.WriteLine("Shane > Not that well. I see him at town events and stuff. Sometimes in the Saloon.");
                            Console.WriteLine("Me > Do you go to the Saloon often?");
                            Console.WriteLine("Shane > Not really. Most Fridays, but other than that not much.");
                            Console.WriteLine("Me > What happens on Fridays?");
                            Console.WriteLine("Shane > Oh, it's just the night everyone goes out. It's the end of the week, you know?");
                            caseH = true;
                            break;
                        case "M": 
                            Console.WriteLine("Me > You live with Marnie? Can you tell me about her relationship with Mayor Lewis?");
                            Console.WriteLine("Shane > Yeah I live with Marnie. She, uh, her and Lewis were friends, I guess?");
                            Console.WriteLine("Me > Good friends? Do you know why she was at his house when she found his body?");
                            Console.WriteLine("Shane > Uh...");
                            if (SaveData.ShaneFriendship > 3)
                            {
                                Console.WriteLine("Shane > Well, Marnie and Lewis were kinda having a relationship... it was a secret though, they didn't tell anyone.");
                                Console.WriteLine("Me > So how did you know about it?");
                                Console.WriteLine("Shane > Well I live with Marnie, you know. It's hard to keep that stuff a secret when you live together.");
                                Console.WriteLine("Me > Ok. And how did Marnie feel about it being a secret?");
                                Console.WriteLine("Shane > Um, not great. She wanted to tell people, I think, but he didn't want to. He was kinda a jerk to her, to be honest.");
                            }
                            else
                            {
                                Console.WriteLine("Shane > No. No idea.");
                                Console.WriteLine("Me > Ok. Thanks Shane.");
                            }
                            caseM = true;
                            break;
                        case "L":
                            break;
                        default: break;
                    }

                }
            }

            else if (SaveData.ShaneCount == 0) //First meeting
            {
                Console.WriteLine("Shane > I don't know you. Why are you talking to me?");
                SaveData.ShaneCount += 1;
            }

            else if (SaveData.ShaneCount >0)
            {
                Random dialogue = new();
                int random = dialogue.Next(1, 15);

                switch (random)
                {
                    case 1: Console.WriteLine("Shane > I hardly know you. Why are you talking to me?"); break;
                    case 2: Console.WriteLine("Shane > What? What do you want? Go away."); break;
                    case 3: Console.WriteLine("Shane > No, I don't have time to chat with you."); break;
                    case 4: Console.WriteLine("Shane > What do you want from me? Money? I'd give you a pot of gold to leave me alone!"); break;
                    case 5: Console.WriteLine("Shane > What do you want? Leave me alone."); break;
                    case 6: Console.WriteLine("Shane > Don't you have work to do?"); break;
                    case 7: Console.WriteLine("Shane > Why are you bothering me? I want to be alone."); break;
                    case 8: Console.WriteLine("Shane > I'm busy, can't you tell ?"); break;
                    case 9: Console.WriteLine("Shane > You again? How many times do I have to tell you to leave me alone?"); break;
                    case 10: Console.WriteLine("Shane > I'm surprised that you're still trying to make friends with me. Haven't I been rude enough to you yet? *sigh*..."); break;
                    case 11: Console.WriteLine("Shane > You're really persistent. I guess I'm just surprised that anyone would be interested in talking to me."); break;
                    case 12: Console.WriteLine("Shane > Hey.Sorry if I came off as rude when we first met. It takes me a while to warm up to strangers."); break;
                    case 13: Console.WriteLine("Shane > Hmm... it's [current time]. Should I throw a frozen pizza in the microwave, or should I wait?"); break;
                    case 14: Console.WriteLine("Shane > Every time I try something new it goes horribly wrong.You learn to just stay in a shell."); break;
                    default: break;
                }
            }
        }
        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Shane?");
            Console.WriteLine("");

            Inventory checkList = new(SaveData);
            checkList.InventoryList();

            var gift = Console.ReadLine().Substring(0, 1).ToUpper();
            Console.WriteLine("");
            
            if (gift == "Beer" && Enums.Items.Beer > 0)
            {
                Console.WriteLine("Shane > Oh wow, " + SaveData.PlayerName + "! How'd you know this is my favorite?");
                SaveData.ShaneFriendship +=2;

                SaveData.MyInventory.TryGetValue(Enums.Items.Beer, out var beerCount);
                beerCount--;
                SaveData.MyInventory[Enums.Items.Beer] = beerCount;
            }

            if (gift == "Quartz" && Enums.Items.Quartz >0)
            {
                Console.WriteLine("Shane > Why are you giving me your garbage?");
                SaveData.ShaneFriendship --;

                SaveData.MyInventory.TryGetValue(Enums.Items.Quartz, out var quartzCount);
                quartzCount--;
                SaveData.MyInventory[Enums.Items.Quartz] = quartzCount;
            }

            else if (gift != "Quartz" || gift != "Beer")
            {
                Console.WriteLine("Shane > Oh, you got me something? Thanks!");
            }
        }
    }
}
