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
            ConsoleMessages.EnterName();
            string playerName = Console.ReadLine();

            while (!(Regex.IsMatch(playerName, "^[A-Za-z]{1,10}$")))
            {
                ConsoleMessages.InValideInputeError();
                playerName = Console.ReadLine();
            }

            return playerName;
        }

        public static int GetSizeOfBoard()
        {
            int boardSize;
            ConsoleMessages.SizeOfBoardMessege();

            while (!(int.TryParse(Console.ReadLine(), out boardSize)) || (boardSize != 6 && boardSize != 8 && boardSize != 10))
            {
                ConsoleMessages.InValideInputeError();
            }

            return boardSize;
        }

        public static int GetOpponentChoise()
        {
            int OpponentChoise;
            ConsoleMessages.OpponentChoosingStatement();
            ConsoleMessages.ComputerChoosing();
            ConsoleMessages.HumanChoosing();

            while (!(int.TryParse(Console.ReadLine(), out OpponentChoise)) || (OpponentChoise != 1 && OpponentChoise != 2))
            {
                ConsoleMessages.InValideInputeError();
            }

            return OpponentChoise;
        }

        public static string GetUserResponseForPlayAgaine()
        {
            ConsoleMessages.PlayAgainMessege();
            string userResponse = Console.ReadLine();

            while (userResponse.ToLower() != "y" && userResponse.ToLower() != "n")
            {
                ConsoleMessages.InValideInputeError();
                userResponse = Console.ReadLine();
            }

            return userResponse;
        }




        public static string GetUserMove(int i_borderSize)
        {
            string userInput = Console.ReadLine();

            while (!(Regex.IsMatch(userInput, "^[A-Z][a-z]>[A-Z][a-z]$")) && userInput != "Q" && userInput != "q")
            {
                ConsoleMessages.InValideInputeError();
                userInput = Console.ReadLine();
            }

            if (userInput != "Q" && userInput != "q")
            {
                if (!CheckMoveBordersAndFormat(userInput, i_borderSize))
                {
                    ConsoleMessages.InValideInputeError();
                    GetUserMove(i_borderSize);
                }
            }

            return userInput;
        }

        public static bool CheckMoveBordersAndFormat(string i_playerMove, int i_borderSize)
        {
            bool isInBorders = true;

            if (Regex.IsMatch(i_playerMove, "^[A-Z][a-z]>[A-Z][a-z]$"))
            {
                if (i_playerMove[0] - 'A' > (i_borderSize - 1) || i_playerMove[1] - 'a' > (i_borderSize - 1) ||
                                   i_playerMove[3] - 'A' > (i_borderSize - 1) || i_playerMove[4] - 'a' > (i_borderSize - 1))
                {
                    isInBorders = false;
                }
            }
            else
            {
                isInBorders = false;
            }

            return isInBorders;
        }

    }
}