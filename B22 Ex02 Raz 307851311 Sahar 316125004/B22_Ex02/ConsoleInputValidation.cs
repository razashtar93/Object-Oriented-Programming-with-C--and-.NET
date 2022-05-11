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

        public static string GetUserMove(int i_BorderSize, string i_UserInput)
        {
            while (!(Regex.IsMatch(i_UserInput, "^[A-Z][a-z]>[A-Z][a-z]$")) && i_UserInput != "Q" && i_UserInput != "q")
            {
                ConsoleMessages.InValideInputeError();
                i_UserInput = Console.ReadLine();
            }

            if (i_UserInput != "Q" && i_UserInput != "q")
            {
                if (!checkMoveBordersAndFormat(i_UserInput, i_BorderSize))
                {
                    ConsoleMessages.InValideInputeError();
                    i_UserInput = Console.ReadLine();
                    GetUserMove(i_BorderSize, i_UserInput);
                }
            }

            return i_UserInput;
        }

        private static bool checkMoveBordersAndFormat(string i_PlayerMove, int i_BorderSize)
        {
            bool isInBorders = true;

            if (Regex.IsMatch(i_PlayerMove, "^[A-Z][a-z]>[A-Z][a-z]$"))
            {
                if (i_PlayerMove[0] - 'A' > (i_BorderSize - 1) || i_PlayerMove[1] - 'a' > (i_BorderSize - 1) ||
                                   i_PlayerMove[3] - 'A' > (i_BorderSize - 1) || i_PlayerMove[4] - 'a' > (i_BorderSize - 1))
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