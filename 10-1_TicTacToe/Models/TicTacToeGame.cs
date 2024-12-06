//Kenny Hedlund
//Chapter 10 - TicTacToe

namespace TicTacToe.Models
{
    // Logic for the game
    public class TicTacToeGame
    {
        // Array to store null, X, or O
        public string[] Board { get; set; } = new string[9];
        // Updates current player (X or O)
        public string CurrentPlayer { get; set; } = "X";
        // Bool for gameover conditions
        public bool GameOver { get; set; }
        // populates winner based on Boolean
        public string Winner { get; set; }
        // Messages displayed
        public string Message { get; set; } = "X's turn";

        // Possible win conditions stored in arrays
        public bool CheckWinner()
        {
            int[][] winPatterns = {
                new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 },
                new[] { 0, 3, 6 }, new[] { 1, 4, 7 }, new[] { 2, 5, 8 },
                new[] { 0, 4, 8 }, new[] { 2, 4, 6 }
            };

            foreach (var pattern in winPatterns)
            {
                if (Board[pattern[0]] != null &&
                    Board[pattern[0]] == Board[pattern[1]] &&
                    Board[pattern[0]] == Board[pattern[2]])
                {
                    Winner = Board[pattern[0]];
                    return true;
                }
            }

            return false;
        }

        // Controls currentl players turn
        public void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";
        }
    }
}
