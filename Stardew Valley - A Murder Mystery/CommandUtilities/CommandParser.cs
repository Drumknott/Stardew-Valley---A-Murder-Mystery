using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.CommandUtilities
{
    public sealed class CommandParser
    {
        public (Commands CommandType, string CommandAgrument) ParseWhatTheUserTyped(string input)
        {
            var parts = input.Split(' ', StringSplitOptions.TrimEntries);

            if (IsInvalidCommand(parts))
            {
                throw new Exception("Ya dun goofed");

            }

            if (parts.Length == 1)
            {
                var parsedCommand = ParseCommandType(parts[0]);
                if (parsedCommand != Commands.Forage && parsedCommand != Commands.Gift && parsedCommand != Commands.Save && parsedCommand != Commands.Help && parsedCommand != Commands.AdminHack)
                {
                    throw new Exception("Ya dun goofed");
                }

                return (parsedCommand, null);
            }
            else
            {
                var commandType = ParseCommandType(parts[0]);
                var commandArgument = ParseCommandArgument(commandType, parts[1]);

                return (commandType, commandArgument);
            }
        }

        private static bool IsInvalidCommand(string[] parts)
        {
            return CommandContainsInvalidParts(parts) || string.IsNullOrWhiteSpace(parts[0]);
        }

        private static bool CommandContainsInvalidParts(string[] parts)
        {
            return parts.Length > 2;
        }

        private Commands ParseCommandType(string commandTypePart)
        {
            return (Commands)Enum.Parse(typeof(Commands), commandTypePart);
        }


        private string ParseCommandArgument(Commands commandType, string commandArgumentPart)
        {
            
            if(commandType == Commands.Go)
            {
                return Enum.Parse(typeof(Enums.Locations), commandArgumentPart).ToString();
            }

            if (commandType == Commands.Check)
            {
                return Enum.Parse(typeof(Checkables), commandArgumentPart).ToString();
            }
            
            if (commandType == Commands.Chat)
            {
                return Enum.Parse(typeof(Enums.People), commandArgumentPart).ToString();
            }

            else throw new Exception("Ya dun goofed");

        }

       
    }
}
