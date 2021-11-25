using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Gift
    {
        private SaveData SaveData { get; set; }

        public Gift(SaveData saveData)
        {
            SaveData = saveData;
        }

        public int GiftMethod(string NPCName, Enums.Items FavGift, Enums.Items DislikedGift, string gift, string LoveGift, string HateGift, string NeutralGift)
        {
            var giftIsValid = Enum.TryParse<Enums.Items>(gift, out var parsedGift);
            var hasInInventory = SaveData.MyInventory.TryGetValue(parsedGift, out var giftCount);
            if (!giftIsValid || !hasInInventory || giftCount < 1)
            {
                Console.WriteLine("You don't have that in your inventory.");
                return 0;
            }

            int friendshipChange;

            if (parsedGift == FavGift)
            {
                Console.WriteLine($"{NPCName} > {LoveGift}"); //loves
                friendshipChange = 2;
            }
            else if (parsedGift == DislikedGift)
            {
                Console.WriteLine($"{NPCName} > {HateGift}"); // hates
                friendshipChange = -1;
            }
            else
            {
                Console.WriteLine($"{NPCName} > {NeutralGift}"); //neutral
                friendshipChange = +1;
            }
            giftCount--;
            SaveData.MyInventory[parsedGift] = giftCount;
            Console.WriteLine(gift + " removed from Inventory.");
            return friendshipChange;
        }
    }
}
