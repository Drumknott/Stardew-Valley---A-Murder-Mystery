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

			foreach(var (item, count) in SaveData.MyInventory.Where(x => x.Value > 0))
            {
				Console.WriteLine($"\t{item}: {count}\n");				
            }					
		}

		public void HatCollectionList()
        {
			Console.WriteLine("\nCOLLECTED HATS\n");
			foreach (var (hat, count) in SaveData.MyHatCollection.Where(x => x.Value >0))
            {
				Console.WriteLine($"\t{hat}: {count}");
			}
		}
	}
}
