using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    public class HatMaus : NPC //okay poke?
    {
        private SaveData SaveData { get; set; }
       
        public HatMaus(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            if (SaveData.HatMaus != true)
            {
                Console.WriteLine("Hat Mouse > Hi. Me sell hats. Okay, poke?");
                Console.WriteLine("Hat Mouse > Come to old old haus, poke. Bring coines.\n");
                SaveData.HatMaus = true;
            }

            while (true)
            {
                Console.WriteLine("Hat Mouse > You want hat?\n");
                Console.WriteLine("Y > Yes\nN > No\n");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "Y":
                        Console.WriteLine("Me > Yes, but I don't have any money.\n");
                        Console.WriteLine("Hat Mouse > We trade, poke. You give gift, I give hat.\n");
                        Console.WriteLine("Trade for a hat?\nY > Yes\nN > No");
                        var tradeForHat = Console.ReadLine().Substring(0, 1).ToUpper();
                        if (tradeForHat == "Y")
                        {
                            Gift();
                        }
                        else
                        {
                            Console.WriteLine("Hat Mouse > No trade, no hat! Okay poke?");
                        }
                        break;
                    case "N":
                        Console.WriteLine("Hat Mouse > No hat? No sense!");
                        return;
                    default: break;
                }
            }
            
             
        }
        public override void Gift()
        {
            string NPCName = "Hat Mouse";
            var FavGift = Enums.Items.Cloth;
            var DislikedGift = Enums.Items.BatteryPack;
            string LoveGift = "Love gift! Thank for bizzness, poke.";
            string HateGift = "Bad trade! More time bring coines, okay poke?";
            string NeutralGift = "Thank for bizzness, poke!";

            Console.WriteLine($"What would you like to trade to {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine().Substring(0, 1).ToUpper();
            Gift giftMethod = new(SaveData);
            int validGift = giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            if (validGift == 0)
            {
                Console.WriteLine("You can't trade nothing for a hat!.");
                return;
            }
            
            Enums.Hats hat = Randomiser();

            if (SaveData.MyHatCollection.TryGetValue(hat, out var hatCount))
            {
                hatCount++;
            }
            else
            {
                hatCount = 1;
            }
            SaveData.MyHatCollection[hat] = hatCount;

            Console.WriteLine($"{hat} added to Collection.");
            SaveData.CollectAllTheHats = true;
        }

        Enums.Hats Randomiser()
        {
            Random randomHat = new();
            int random = randomHat.Next(0, 20);

            var randomForage = (Enums.Hats)random;
            return randomForage;
        }
    }
}
