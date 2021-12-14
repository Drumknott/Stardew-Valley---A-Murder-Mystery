using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Harvey : NPC
    {
        private SaveData SaveData { get; set; }

        public Harvey (SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
            SaveData.LastChat = "Harvey";

                if (SaveData.HarveyCount == 0) //first meeting
                {
                    Console.WriteLine("Harvey > It's a pleasure to meet you. I'm Harvey, the local doctor.");
                    SaveData.HarveyCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Harvey > I perform regular check-ups and medical procedures for all the residents of Pelican Town. It's rewarding work."); break;
                        case 1: Console.WriteLine("Harvey > We sell a few over-the-counter medicines at the clinic... feel free to stop by if you're feeling exhausted. I know that being a detective is pretty tiring work... don't overdo it!"); break;
                        case 2: Console.WriteLine("Harvey > I feel responsible for the health of this whole community... it's kind of stressful. It's a pretty small community, and I'm fortunate to be able to build a good relationship with my patients."); break;
                        case 3: Console.WriteLine("Harvey > Feel free to stop by my office if you're ever feeling ill. You're young, though. You'll probably stay healthy without trying."); break;
                        case 4: Console.WriteLine("Harvey > Remember to cover your mouth when you sneeze. Then make sure to wash your hands."); break;
                        case 5: Console.WriteLine("Harvey > Nutrition is important, so make sure and eat well. Try to increase your vegetable intake! Home-cooked meals are best. Do you cook?"); break;
                        case 6: Console.WriteLine("Harvey > It's a beautiful day, isn't it? I wish I had less work to do."); break;
                        case 7: Console.WriteLine("Harvey > If you want to hang out in my apartment, that's okay with me. I live above the clinic."); break;
                        case 8: Console.WriteLine("Harvey > I came here because I liked the small-town atmosphere, and the potential for a holistic approach to patient care. I've grown to really love it."); break;
                        case 9: Console.WriteLine("Harvey > Hmm... I'm struggling to make ends meet. I don't have enough patients. I guess I should try to get patients from the neighboring towns..."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > How are you doing, Harvey?");
                        SaveData.HarveyFriendship++;
                        break;
                    case "G":
                        Console.WriteLine("Me > Would you like this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > Can I ask you about Mayor Lewis?");
                        Investigate();
                        Console.WriteLine("Me > Ok, thank you Harvey. You've been very helpful.");
                        break;
                    case "L": 
                        SaveData.HarveyCount++;
                        return;
                    default: break;
                }               
            }
        }
        public override void Gift()
        {
            string NPCName = "Harvey";
            var FavGift = Enums.Items.Coffee;
            var DislikedGift = Enums.Items.Coral;
            string LoveGift = "It's for me? This is my favorite stuff! It's like you read my mind.";
            string HateGift = "...I think I'm allergic to this.";
            string NeutralGift = "Thanks. That's very kind of you.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine().Substring(0, 1).ToUpper();
            Gift giftMethod = new(SaveData);
            int friendshipChange = giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            SaveData.HarveyFriendship += friendshipChange;            
        }

        bool CaseH;
        bool CaseR;
        bool CaseI;
        bool Case4;

        void Investigate()
        {
            Console.WriteLine("Harvey > Of course, Detective. What can I halp you with?\n");

            while (true)
            {
                if (SaveData.PTSD == true)
                {
                    if (CaseH && CaseI && CaseR && Case4) return;
                }
                else if (CaseH == true && CaseI == true && CaseR == true)
                {
                    return;
                }

                Console.WriteLine("\nH > You must know everyone in town pretty well, Doctor. How well did you know Lewis?");
                Console.WriteLine("R > I understand you have Mayor Lewis' remains at your clinic?");
                Console.WriteLine("B > How was the body when you found it?");
                if (SaveData.PTSD == true) Console.WriteLine("K > Have you ever seen Kent for PTSD?");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "H":
                        Console.WriteLine("Harvey > I knew him pretty well. He was a nice man, always had time to say hello to everyone around town.");
                        Console.WriteLine("Me > Do you know if he had any enemies?");
                        Console.WriteLine("Harvey > Not enemies, no. Pierre wasn't happy about Lewis' idea to turn the old Community Centre in a Joja Mart warehouse,");
                        Console.WriteLine("Harvey > but it's not something he'd kill over.");
                        CaseH = true;
                        break;
                    case "R":
                        Console.WriteLine("Harvey > That's correct Detective. Do you want to see it?");
                        Console.WriteLine("Me > Well I'm more interested in the findings of the autopsy. Do you know how he died??");
                        Console.WriteLine("Harvey looks uncomfortable.");
                        Console.WriteLine("Harvey > Um, I've not actually had a chance to do it yet I'm afraid.");
                        Console.WriteLine("Me > Well, we'd better get started then hadn't we?\n");
                        Console.WriteLine("A > Do the Autopsy now");
                        Console.WriteLine("T > Another Time");

                        var investigate = Console.ReadLine().Substring(0, 1).ToUpper();
                        if (investigate == "A")
                        {
                            Autopsy();
                            CaseR = true;
                        }
                        else break;
                        break;
                    case "B":
                        Console.WriteLine("Harvey looks alarmed.");
                        Console.WriteLine("Oh, I didn't find the body, Detective, Marnie-");
                        Console.WriteLine("Me > My apologies. I should have said, 'How was the body when you attended the scene?'");
                        Console.WriteLine("Harvey > Well, he was face down on the living room floor. He was still warm but there was no pulse or breathing.");
                        Console.WriteLine("Harvey > Of course I started CPR but it was too late, and after thirty minutes we had to stop.");
                        Console.WriteLine("Me > 'We'?");
                        Console.WriteLine("Harvey > Well Marnie called me, and as soon as I got there I sent her to run to the saloon for help, as it's right next door.");
                        Console.WriteLine("Harvey > Gus came, with Willy and Shane. Shane comforted Marnie while Gus and Willy helped me.");
                        Console.WriteLine("Me > Marnie is the one who found the body?");
                        Console.WriteLine("Harvey > Yes sir.");
                        Console.WriteLine("Me > Do you know what she was doing at his house?");
                        Console.WriteLine("Harvey > No idea I'm afraid.");
                        Console.WriteLine("And what about the others?");
                        if (SaveData.ShaneCount == 0)
                        {
                            Console.WriteLine("Me > Shane?");
                            Console.WriteLine("Harvey > Shane is Marnie's nephew. He lives with her.");
                        }
                        if (SaveData.GusCount == 0)
                        {
                            Console.WriteLine("Me > Willy?");
                            Console.WriteLine("Harvey > Willy's a fisherman. He's got a little shack down on the quay.");
                        }
                        if (SaveData.WillyCount == 0)
                        {
                            Console.WriteLine("Me > Gus?");
                            Console.WriteLine("Harvey > Gus runs the saloon. ");
                        }
                        Console.WriteLine("Harvey > They're all good people, Detective. I don't believe any of them would have killed Mayor Lewis.");
                        CaseI = true;
                        break;
                    case "K":
                        Console.WriteLine("Harvey > Well, without breaching Doctor/Patient confidentiality, all I can say is that Kent has suffered through");
                        Console.WriteLine("Harvey > some traumatic experiences while in the army, and is recieving support in dealing with that.");
                        Console.WriteLine("Me > Would you say he's capable of killing a man?");
                        Console.WriteLine("Harvey > We're all capable of it, Detective, if we really wanted to.");
                        Console.WriteLine("Harvey > But I wouldn't say Kent is any more likely to have killed Mayor Lewis than you or I.");
                        Case4 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }

        void Autopsy()
        {
            Console.WriteLine("Harvey takes you to one of the prive rooms at the back of his clinic. Here he proceeds to set up various medical equipment,");
            Console.WriteLine("before opening a stainless stell door and pulling out a trolley with a body bag on it.");
            Console.WriteLine("Harvey > Are you ready?");
            Console.WriteLine("You nod. Harvey unzips the body bag, and you can see the body of Mayor Lewis. His skin is grey, and his mouth gapes open, completely still.");
            Console.WriteLine("Harvey points.");
            Console.WriteLine("Harvey > Look at these bruises and swelling around his head. That looks like a blunt force trauma. I'm going to do a full examination,");
            Console.WriteLine("but I have a feeling that will be the answer to your question.");
            Console.WriteLine("Harvey works away for nearly two hours, inspecting and taking samples. Finally he sighs, takes off his gloves, and looks at you.");
            Console.WriteLine("Harvey > It's as I thought. All his blood tests are normal, and I cant find any other evidence of injury or disease.");
            Console.WriteLine("Harvey > Mayor Lewis was killed by a blow to the back of his head. His occipital skull is fractured, so it was probably something heavy.\n");
            Console.WriteLine("Blunt force trauma to the back of the head. So he didn't even see it coming. Well that's something to think about.");
            SaveData.Autopsy = true;
            SaveData.Vivisection = true;            
        }
    }
}
