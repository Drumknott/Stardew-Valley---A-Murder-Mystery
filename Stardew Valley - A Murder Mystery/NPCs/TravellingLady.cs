using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stardew_Valley___A_Murder_Mystery.Enums;

namespace Stardew_Valley___A_Murder_Mystery
{
    public class TravellingLady
    {
        private SaveData SaveData { get; set; }

        public TravellingLady(SaveData saveData)
        {
            SaveData = saveData;
        }

        string[] forSale = {"Flashlight", "BatteryPack", "Coffee", "Mysterious Key", "Beer", "VoidEssence", "JojaCola" };

        public void Chat()
        {
            Console.WriteLine("Travelling Merchant > Hello there! Can I interest you in anything? I smuggled these right out of the Gotoro Empire.\nTravelling Merchant > All items cost 3 gems.\n");
            
            foreach (string item in forSale)
            {
                Console.WriteLine(item +" : 1");
            }
            Console.WriteLine("\nWould you like to buy anything?\nY > Yes\nN > No");

            if (Console.ReadLine() == "Y")
            {
                Shop();
            }
            else
            {
                Console.WriteLine("Travelling Merchant > No problem. Have a nice day!");
            }
        }

        void Shop()
        {
            while (true)
            {
                Console.WriteLine("What would you like?");
                string item = Console.ReadLine();

                if (forSale.Contains(item))
                {
                    Console.WriteLine("And how will you pay?");
                    Inventory inventory = new(SaveData);
                    inventory.InventoryList();
                    string payment = Console.ReadLine();

                    string itemToRemove = item;
                    forSale = forSale.Where(i => i != itemToRemove).ToArray();

                    var paymentIsValid = Enum.TryParse<Enums.Items>(payment, out var paymentType);
                    SaveData.MyInventory.TryGetValue(paymentType, out var paymentCount);
                    if (!paymentIsValid || paymentCount < 3)
                    {
                        Console.WriteLine("You don't have enough of those in your inventory. Try again?\nY > Yes\nN > No");
                        if (Console.ReadLine().Substring(0, 1).ToUpper() == "N") return;
                    }
                    else
                    {
                        Console.WriteLine($"3x {payment} removed from Inventory.\n");
                        paymentCount -= 3;
                        SaveData.MyInventory[paymentType] = paymentCount;
                        Console.WriteLine("Travelling Merchant > Wonderful! Thank you for your business.");


                        switch (item)
                        {
                            case "Flashlight":
                                SaveData.Flashlight = true;
                                Console.WriteLine("You have obtained the Flashlight.");
                                return;
                            case "Mysterious Key":
                                SaveData.SewerKey = true;
                                Console.WriteLine("You have obtained the Mysterious Key. I wonder what it opens?");
                                return;
                            case "BatteryPack":
                            case "Coffee":
                            case "Beer":
                            case "VoidEssence":
                            case "JojaCola":
                                Enum.TryParse<Enums.Items>(item, out var itemType);                                
                                if (SaveData.MyInventory.TryGetValue(itemType, out var itemCount))
                                { 
                                    itemCount++;
                                }
                                else
                                {
                                    itemCount = 1;
                                }
                                SaveData.MyInventory[itemType] = itemCount;
                                return;
                            default: return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, I didn't understand that. Try again?\nY > Yes\nN > No");
                    if (Console.ReadLine().Substring(0, 1).ToUpper() == "N") return;
                }                
            }
        }
    }
}
