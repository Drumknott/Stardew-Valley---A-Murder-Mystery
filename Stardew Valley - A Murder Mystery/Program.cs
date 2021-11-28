using System.Collections.Generic;
using Stardew_Valley___A_Murder_Mystery.CommandUtilities;
using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Linq;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphic graphic = new();
            graphic.DisplayGraphic();
            Console.WriteLine("N > NEW GAME");
            Console.WriteLine("L > LOAD GAME");
            var Start = Console.ReadLine().Substring(0, 1).ToUpper();

            SaveData saveData;
            if (Start == "L")
            {
                saveData = SaveManager.Load();
            }
            else 
            {
                saveData = new();

                Console.WriteLine("Welcome to STARDEW VALLEY - A MURDER MYSTERY");
                Console.WriteLine("");
                Console.WriteLine("Are you ready to begin? Y/N");
                var Begin = Console.ReadLine().Substring(0, 1).ToUpper();

                if (Begin == "N")
                {
                    Console.WriteLine("No problem. Come back when you're ready to play.");
                    Console.ReadKey();
                    return;                
                }


                Random Murderer = new();
                int random = Murderer.Next(0, 2);

                switch (random)
                {
                    case 0: saveData.TheMurderer = "Pierre"; break;
                    case 1: saveData.TheMurderer = "Marnie"; break;
                    case 2: saveData.TheMurderer = "Kent"; break;
                }

                Intro Opening = new(saveData);
                Opening.Opening();

                Pam newNPC = new(saveData);
                newNPC.Chat();
            }

            while (true) //DAY 0
            {
                if (saveData.DayCount >0) break;

                BusStop busStop = new(saveData);
                if (saveData.FreshOffTheBus == false) busStop.Enter();

                DoStuffMethod();
            }
                        
            while (true)
            {
                DoStuffMethod();                      
            }

            void DoStuffMethod()
            {
                Achievements achievements = new(saveData);
                achievements.CheckAchievements();

                DayManager dayManager = new(saveData);
                dayManager.CheckDayCount();

                Commands commandType;
                string commandArgument;
                while (true)
                {
                    graphic.MethodGraphic();
                    var response = Console.ReadLine();

                    var commandParser = new CommandParser();
                    try
                    {
                        (commandType, commandArgument) = commandParser.ParseWhatTheUserTyped(response);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("I'm sorry, I didn't understand that. Try again?");
                    }
                }

                if (commandType == Commands.Go)
                {
                    ChooseLocation Location = new();
                    var ChosenLocation = Location.ChooseLocationMethod(commandArgument, saveData);
                    
                    Random travel = new();
                    int description = travel.Next(0, 3);
                    switch (description)
                    {
                        case 0:
                            Console.WriteLine("\nThe weather is lovely as you head towards your destination.");
                            break;
                        case 1:                           
                            Console.WriteLine("\nThe sun beams down on you as you walk, and birds sing in the trees.");
                            break;
                        case 2:                          
                            Console.WriteLine("\nClouds gather overhead, and you're afraid it might rain soon.");
                            break;
                    }
                    ChosenLocation.Enter();
                }

                if (commandType == Commands.Check)
                {
                    var parsedcheckable = (Checkables)Enum.Parse(typeof(Checkables), commandArgument);

                    if (parsedcheckable == Checkables.Inventory)
                    {
                        Inventory checkList = new(saveData);
                        checkList.InventoryList();
                    }

                    if (parsedcheckable == Checkables.Casefile)
                    {
                        CaseFile notes = new(saveData);
                        notes.Notes();
                    }

                    if (parsedcheckable == Checkables.Locations)
                    {
                        AvailablePlaces check = new(saveData);
                        check.ViewLocations();
                    }

                    if (parsedcheckable == Checkables.Achievements)
                    {
                        Achievements view = new(saveData);
                        view.ViewAchievements();
                    }
                }

                if (commandType == Commands.Forage)
                {
                    ChooseLocation Location = new();
                    var ChosenLocation = Location.ChooseLocationMethod(saveData.LastVisited, saveData);
                    ChosenLocation.Forage();
                }

                if (commandType == Commands.Gift)
                {
                    ChooseNPC npc = new();
                    var chosenNPC = npc.ChooseNPCMethod(saveData.LastChat, saveData);
                    chosenNPC.Gift();
                }

                if (commandType == Commands.Save)
                {
                    saveData.Save();
                    Console.WriteLine("The game has been saved.");
                    Console.WriteLine("");
                    Console.WriteLine("Enter > Continue");
                }

                if (commandType == Commands.Help)
                {
                    PlayerHelp tips = new(saveData);
                    tips.Help();
                }

                if (commandType == Commands.Chat)
                {
                    ChooseNPC chooseNPC = new();
                    var chatNPC = chooseNPC.ChooseNPCMethod(commandArgument, saveData);
                    string[] presentNPCs = { saveData.npc1, saveData.npc2, saveData.npc3, saveData.npc4, saveData.npc5, saveData.npc6, saveData.npc7, saveData.npc8, saveData.npc9, saveData.npc10, saveData.npc11, saveData.npc12, saveData.npc13 };                   
                    bool availableNPCs = presentNPCs.Contains(commandArgument);

                    if (availableNPCs && saveData.DayCount <6)
                    {
                        chatNPC.Chat();
                    }
                    else if (saveData.DayCount == 6 && commandArgument != "Krobus")
                    {
                        chatNPC.Chat();
                    }
                    else
                    {
                        Console.WriteLine(commandArgument + " isn't here right now.");
                    }
                }

                if (commandType == Commands.AdminHack)
                {
                    string murderer = saveData.TheMurderer;
                    Console.WriteLine(murderer);
                }
            }
        }
    }        
}
