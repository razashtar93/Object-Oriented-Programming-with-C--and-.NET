using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace B22_Ex02
{
    public class ConsoleInputValidation
    {
        public static string GetPlayerName()
        {
            consoleMessages.EnterName();
            string playerName = Console.ReadLine();

            while (!(Regex.IsMatch(playerName, "^[A-Za-z]{1,10}$")))
            {
                consoleMessages.InValideInputeError();
                playerName = Console.ReadLine();
            }

            return playerName;
        }

        public static int GetSizeOfBoard()
        {
            int boardSize;
            consoleMessages.SizeOfBoardMessege();

            while (!(int.TryParse(Console.ReadLine(), out boardSize)) || (boardSize != 6 && boardSize != 8 && boardSize != 10))
            {
                consoleMessages.InValideInputeError();
            }

            return boardSize;
        }

        public static int GetOpponentChoise()
        {
            int OpponentChoise;
            consoleMessages.OpponentChoosingStatement();
            consoleMessages.ComputerChoosing();
            consoleMessages.HumanChoosing();

            while (!(int.TryParse(Console.ReadLine(), out OpponentChoise)) || (OpponentChoise != 1 && OpponentChoise != 2))
            {
                consoleMessages.InValideInputeError();
            }

            return OpponentChoise;
        }

        public static string GetUserResponseForPlayAgaine()
        {
            consoleMessages.PlayAgainMessege();
            string userResponse = Console.ReadLine();

            while (userResponse.ToLower() != "y" && userResponse.ToLower() != "n")
            {
                consoleMessages.InValideInputeError();
                userResponse = Console.ReadLine();
            }

            return userResponse;
        }

    }
}
