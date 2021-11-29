using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    public abstract class NPC
    {
        public void NPCDialogue(string dialogue)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(dialogue);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public abstract void Chat();
        public abstract void Gift();
    }
}
