using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    public class Inventory
    {
		private SaveData SaveData { get; set; }

		public Inventory(SaveData saveData)
		{
			SaveData = saveData;
		}
		public void InventoryList()
		{
			Console.WriteLine("");
			Console.WriteLine("INVENTORY");
			Console.WriteLine("");

			foreach(var (item, count) in SaveData.MyInventory)
            {
				Console.WriteLine($"\t{item}: {count}");
            }

			//if (SaveData.LewisStatue >0) Console.WriteLine("Solid Gold Statue of Mayor Lewis x"+SaveData.LewisStatue);
			//if (SaveData.Amethyst >0) Console.WriteLine("Amethyst x"+SaveData.Amethyst);
			//if (SaveData.Horseradish >0) Console.WriteLine("Wild Horseradish x"+SaveData.Horseradish);
			//if (SaveData.LewisStatue > 0) Console.WriteLine("Solid Gold Statue of Mayor Lewis x"+SaveData.LewisStatue);
			//if (SaveData.CompleteBreakfast > 0) Console.WriteLine("Complete Breakfast x" + SaveData.CompleteBreakfast);
			//if (SaveData.Holly > 0) Console.WriteLine("Holly x" + SaveData.Holly);
			//if (SaveData.CrabCakes > 0) Console.WriteLine("Crab Cakes x" + SaveData.CrabCakes);
			//if (SaveData.Amaranth > 0) Console.WriteLine("Amaranth x" + SaveData.Amaranth);
			//if (SaveData.Coffee > 0) Console.WriteLine("Coffee x" + SaveData.Coffee);
			//if (SaveData.Coral > 0) Console.WriteLine("Coral x" + SaveData.Coral);
			//if (SaveData.MapleBar > 0) Console.WriteLine("Maple Bar x" + SaveData.MapleBar);
			//if (SaveData.Coal > 0) Console.WriteLine("Coal x" + SaveData.Coal);
			//if (SaveData.FrozenTear > 0) Console.WriteLine("Frozen Tear x" + SaveData.FrozenTear);
			//if (SaveData.Clay > 0) Console.WriteLine("Clay x" + SaveData.Clay);
			//if (SaveData.Cloth > 0) Console.WriteLine("Cloth x" + SaveData.Cloth);
			//if (SaveData.FishTaco > 0) Console.WriteLine("Fish Taco x" + SaveData.FishTaco);
			//if (SaveData.Coconut > 0) Console.WriteLine("Coconut x" + SaveData.Coconut);
			//if (SaveData.PrismaticShard > 0) Console.WriteLine("Prosmatic Shard x" + SaveData.PrismaticShard);
			//if (SaveData.GoatCheese > 0) Console.WriteLine("Goat's Cheese x" + SaveData.GoatCheese);
			//if (SaveData.Bread > 0) Console.WriteLine("Bread x" + SaveData.Bread);
			//if (SaveData.BatteryPack > 0) Console.WriteLine("Battery Pack x" + SaveData.BatteryPack);
			//if (SaveData.Honey > 0) Console.WriteLine("Honey x" + SaveData.Honey);
			//if (SaveData.Diamond > 0) Console.WriteLine("Diamond x" + SaveData.Diamond);
			//if (SaveData.Beer > 0) Console.WriteLine("Beer x" + SaveData.Beer);
			//if (SaveData.Quartz > 0) Console.WriteLine("Quartz x" + SaveData.Quartz);
			//if (SaveData.BeanHotpot > 0) Console.WriteLine("Bean Hotpot x" + SaveData.BeanHotpot);
			//if (SaveData.Emerald > 0) Console.WriteLine("Emerald x" + SaveData.Emerald);
			//if (SaveData.Seaweed > 0) Console.WriteLine("Seaweed x" + SaveData.Seaweed);
			//if (SaveData.ChocolateCake > 0) Console.WriteLine("Chocolate Cake x" + SaveData.ChocolateCake);
			//if (SaveData.Clam > 0) Console.WriteLine("Clam x" + SaveData.Clam);
			//if (SaveData.Leek > 0) Console.WriteLine("Leek x" + SaveData.Leek);
			//if (SaveData.Coleslaw > 0) Console.WriteLine("Coleslaw x" + SaveData.Coleslaw);
			//if (SaveData.Daffodil > 0) Console.WriteLine("Daffodil x" + SaveData.Daffodil);
			//if (SaveData.Risotto > 0) Console.WriteLine("Fiddlehead Risotto x" + SaveData.Risotto);
			//if (SaveData.VoidEgg > 0) Console.WriteLine("Void Egg x" + SaveData.VoidEgg);
			//if (SaveData.FarmersLunch > 0) Console.WriteLine("Farmer's Lunch x" + SaveData.FarmersLunch);
			//if (SaveData.Octopus > 0) Console.WriteLine("Octopus x" + SaveData.Octopus);
			//if (SaveData.FriedCalamari > 0) Console.WriteLine("Fried Calamari x" + SaveData.FriedCalamari);
			//if (SaveData.Corn > 0) Console.WriteLine("Corn x" + SaveData.Corn);
			//if (SaveData.VoidEssence > 0) Console.WriteLine("Void Essence x" + SaveData.VoidEssence);
			//if (SaveData.RedMushroom > 0) Console.WriteLine("Red Mushroom x" + SaveData.RedMushroom);
			Console.WriteLine("");
			Console.WriteLine("Enter > Back");
			Console.ReadKey();
		}

	}
}
