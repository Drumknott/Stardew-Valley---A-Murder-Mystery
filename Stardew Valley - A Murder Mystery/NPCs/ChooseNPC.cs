using Stardew_Valley___A_Murder_Mystery.Enums;
using Stardew_Valley___A_Murder_Mystery.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class ChooseNPC
    {       
        public NPC ChooseNPCMethod(string chosenNPC, SaveData saveData)
        {
            var parsedNPC = (People)Enum.Parse(typeof(People), chosenNPC);

            NPC npc;
            switch (parsedNPC)
            {
                case People.Abigail: npc = new Abigail(saveData); break;
                case People.Alex: npc = new Alex(saveData); break;
                case People.Caroline: npc = new Caroline(saveData); break;
                case People.Demetrius: npc = new Demetrius(saveData); break;
                case People.Elliott: npc = new Elliot(saveData); break;
                case People.Emily: npc = new Emily(saveData); break;
                case People.Evelyn: npc = new Evelyn(saveData); break;
                case People.Farmer: npc = new Farmer(saveData); break;
                case People.George: npc = new George(saveData); break;
                case People.Morris: npc = new Morris(saveData); break;
                case People.Gus: npc = new Gus(saveData); break;
                case People.HatMouse: npc = new HatMaus(saveData); break;
                case People.Hayley: npc = new Hayley(saveData); break;
                case People.Jodi: npc = new Jodi(saveData); break;
                case People.Kent: npc = new Kent(saveData); break;
                case People.Krobus: npc = new Krobus(saveData); break;
                case People.Leah: npc = new Leah(saveData); break;
                case People.Linus: npc = new Linus(saveData); break;
                case People.Marlon: npc = new Marlon(saveData); break;
                case People.Marnie: npc = new Marnie(saveData); break;
                case People.Maru: npc = new Maru(saveData); break;
                case People.Pam: npc = new Pam(saveData); break;
                case People.Penny: npc = new Penny(saveData); break;
                case People.Pierre: npc = new Pierre(saveData); break;
                case People.Robin: npc = new Robin(saveData); break;
                case People.Sam: npc = new Sam(saveData); break;
                case People.Sebastian: npc = new Sebastian(saveData); break;
                case People.Shane: npc = new Shane(saveData); break;
                case People.Willy: npc = new Willy(saveData); break;
                case People.Wizard: npc = new Wizard(saveData); break;
                case People.Harvey: npc = new Harvey(saveData); break;
                
                default:
                    throw new Exception("Oops,something went wrong. Try that again.");
            }
            saveData.LastChat = chosenNPC;
            return npc;
        }

        public void ChatOptions()
        {
            Console.WriteLine("\nC > Chat\nG > Gift\nI > Investigate\nL > Leave\n");           
        }    
    }
}
