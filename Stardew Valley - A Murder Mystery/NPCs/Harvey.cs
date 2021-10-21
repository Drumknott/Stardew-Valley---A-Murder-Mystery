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
            SaveData.LastChat = "Harvey";

            if (SaveData.HarveyCount == 0) //first meeting
            {
                Console.WriteLine("Harvey > It's a pleasure to meet you. I'm Harvey, the local doctor.");
                Autopsy();
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
                //player dialogue options
                Console.WriteLine("C"); //chat
                Console.WriteLine("G"); //gift
                Console.WriteLine("I"); //investigate

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "chat":
                        Console.WriteLine("");
                        SaveData.HarveyFriendship++;
                        break;
                    case "gift":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    default: break;
                }

                SaveData.HarveyCount++;
            }
        }
        public override void Gift()
        {

        }

        void Investigate()
        {
            Console.WriteLine("A > Autopsy");
            var investigate = Console.ReadLine();
            if (investigate == "A")
            {
                Autopsy();
            }
        }

        void Autopsy()
        {
            Console.WriteLine("Do Autopsy");

            AvailablePlaces call = new(SaveData);
                call.IncreaseDayCount();
        }
    }
}
