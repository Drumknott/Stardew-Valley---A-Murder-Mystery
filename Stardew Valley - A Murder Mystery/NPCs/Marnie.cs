using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Marnie : NPC
    {
        private SaveData SaveData { get; set; }

        public Marnie(SaveData saveData)
        {
            SaveData = saveData;
        }

        bool caseP { get; set; }
        bool caseI { get; set; }
        bool caseK { get; set; }
        bool caseS { get; set; }

        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Marnie";

                if (SaveData.MarnieCount == 0)
                {
                    Console.WriteLine("Ah, Pam told me you just arrived. I'm Marnie! I sell livestock and animal care products at my ranch. You should swing by some time.");
                    SaveData.MarnieCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) // Marnie random dialogue
                    {
                        case 0: Console.WriteLine("Marnie > I love animals, Detective " + SaveData.PlayerName + ". If you treat yours well I'm sure we'll become good friends!"); break;
                        case 1: Console.WriteLine("Marnie > Animals are so innocent, so sweet. And If I don't look after them, who will? I just hope my chickens aren't too upset when I take their eggs."); break;
                        case 2: Console.WriteLine("Marnie > You've been here a while, now... how's your investigating going?"); break;
                        case 3: Console.WriteLine("Marnie > My nephew Shane has been staying at my place the last few months.He helps me out with the chickens, so I'm not complaining."); break;
                        case 4: Console.WriteLine("Marnie > You can use a scythe to cut feed from grass.Or you can buy it from me, of course! I could use the cash... Adios."); break;
                        case 5: Console.WriteLine("Marnie > You can catch me at the saloon most nights. Animals are great company, but I need to spend some time with people, too."); break;
                        case 6: Console.WriteLine("Marnie > I would be so lonely if Shane ever moved out."); break;
                        case 7: Console.WriteLine("Marnie > Hey there, it's good to see ya! Feel free to visit us any time you please."); break;
                        case 8: Console.WriteLine("Marnie > Have you been to that strange tower west of my house? One time I heard this terrible, otherworldly noise coming from there. I would avoid that place if I were you..."); break;
                        case 9:
                            Console.WriteLine("Marnie quickly wipes away a tear and tries to pretend she wasn't crying.");
                            Console.WriteLine("Marnie > Oh, Hi Detective. What can I do for you?");
                            break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C": Console.WriteLine("Hi Marnie. How are you?");
                        if (SaveData.MarnieAndMarlon == true)
                        {
                            //happy Marnie
                            Console.WriteLine("Marnie smiles.");
                            Console.WriteLine("Marnie > Oh I'm great, thank you for asking Detective.");
                        }
                        else
                        {
                            Console.WriteLine("Marnie looks uncomfortable.");
                            Console.WriteLine("Marnie > Oh you know, getting on with things. The animals always need me!");
                        }
                        break;
                    case "G": Console.WriteLine("Marnie, I thought you might like this?");
                        Gift();
                        break;
                    case "I": Console.WriteLine("Hi Marnie. I'm here on official business I'm afraid. Can I ask you a few questions about Mayor Lewis?");
                        Console.WriteLine("Marnie > Oh, um, yes I suppose.");
                        Investigate();
                        Console.WriteLine("Well, thank you for talking with me Marnie. This has been very informative.");
                        break;
                    case "L": SaveData.MarnieCount++;
                        return;
                    default: break;
                }              
            }  
        }

        public override void Gift()
        {
            string NPCName = "Marnie";
            var FavGift = Enums.Items.FarmersLunch;
            var DislikedGift = Enums.Items.Clay;
            string LoveGift = "This is an incredible gift! Thanks!!";
            string HateGift = "This is worthless. I don't understand you.";
            string NeutralGift = "Thank you! This looks nice.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
           
        }

        void Investigate()
        {
            while (true)
            {
                if (caseP == true && caseK == true && caseI == true && caseS == true) break;

                Console.WriteLine("P > You called the Police?");
                Console.WriteLine("K > Did you kill Lewis?");
                if (SaveData.MarnieAndLewis == true) Console.WriteLine("I > Is it true you were having a relationship with Lewis?");
                SaveData.MyInventory.TryGetValue(Enums.Items.LewisStatue, out int lewisStatue);
                if (lewisStatue > 0) Console.WriteLine("S > Have you ever seen this before?");                
                Console.WriteLine("L > Leave");

                var answer = Console.ReadLine().Substring(0, 1).ToUpper();
                if (answer == "L") break;

                else switch (answer)
                {
                    case "P":
                        Console.WriteLine("Me > Firstly, according to my case notes it was you who discovered Lewis' body and called the police. Can you tell me about the events of that evening?");
                        Console.WriteLine("Marnie > Um, well, I called over to Lewis' house to... drop something off. And when I went in he was...");
                            if (SaveData.TheMurderer != "Marnie") 
                            {
                                Console.WriteLine("Marnie bursts into tears.");
                                Console.WriteLine("Marnie > He was slumped on the floor, and he was bleeding from his head, and-");
                                Console.WriteLine("Marnie pauses and atkes a deep breath, before continuing slowly.");                           
                            }
                            else
                            {
                                Console.WriteLine("Marnie > He was just slumped on the floor. And he was bleeding from his head.");
                            }
                            Console.WriteLine("Marnie > I called Harvey, he's our local doctor. He told me to get some extra help, so I ran to the saloon next door.");
                            Console.WriteLine("Marnie > Gus and Willy came to help, and Shane, that's my nephew, he came to look after me.");
                            Console.WriteLine("Marnie > But Harvey said it was too late, so I called the police...\n");
                            Console.WriteLine("Me > What were you dropping off?");
                            Console.WriteLine("Marnie > ...Truffle oil. He wanted some truffle oil.");
                            Console.WriteLine("Me > Truffle oil?");
                            Console.WriteLine("Marnie > Yes. You know what it's for.");
                            caseP = true;
                        break;
                    case "K":
                        Console.WriteLine("Me > Did you kill Lewis?");
                            if (SaveData.TheMurderer == "Marnie")
                            {
                                if (SaveData.MarnieAndLewis == true) 
                                {
                                    Console.WriteLine("Marnie > No. And please don't ask me that again.");
                                }
                                else
                                {
                                    Console.WriteLine("Marnie > No. Why would I do a thing like that?");
                                }
                            }
                            else
                            {
                                if (SaveData.MarnieAndLewis == true)
                                {
                                    Console.WriteLine("Marnie > No of course not! I know our relationship wasn't perfect but I would never hurt him!");
                                }
                                else
                                {
                                    Console.WriteLine("Marnie > I would never do a thing like that, to animal or person. Shame on you for asking, Detective!");
                                }
                            }
                            caseK = true;
                        break;
                    case "I" when (SaveData.MarnieAndLewis == true):
                        Console.WriteLine("Is it true that you and Lewis were in a relationship? Why was it a secret?");
                        Console.WriteLine("Marnie gasps.");
                        Console.WriteLine("Marnie > How do you know about that...?");
                            if (SaveData.ShaneFriendship > 4)
                            {
                                Console.WriteLine("I can't disclose that I'm afraid.");
                            }
                            else
                            {
                                Console.WriteLine("Shane mentioned it. He said Lewis wasn't treating you very well.");
                            }
                            Console.WriteLine("Marnie > Yes, we were. I wanted to tell people but Lewis thought it would affect his standing as mayor.");
                            Console.WriteLine("Marnie > So I didn't.");
                            Console.WriteLine("Me > And how did you feel about that?");
                            Console.WriteLine("Marnie > I felt like he was ashamed of me sometimes. We argued about it.");
                            if (SaveData.TheMurderer != "Marnie") Console.WriteLine("Marnie > It doesn't mean I killed him though. All couples fight.");
                            caseI = true;
                        break;
                    case "S" when (Enums.Items.LewisStatue > 0): // lewis statue
                            if (SaveData.TheMurderer == "Marnie")
                            {
                                Console.WriteLine("Marnie > No, never. Is that Lewis?");
                            }
                            else
                            {
                                Console.WriteLine("Marnie > That's Lewis' statue of himself. He loved that thing, arrogant ass.");
                                Console.WriteLine("She rolls her eyes.");
                                Console.WriteLine("Marnie > He had Clint make it from solid gold. Wouldn't tell me where he got the money from.");
                                Console.WriteLine("Marnie > Why is it so dirty?");
                            }
                        caseS = true;
                        break;
                    default: break;
                }
            }
        }      
    }
}
