//Kenny Hedlund
//Chapter 10 - TicTacToe

using _10_1_TicTacToe.Models;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        // Show board from Index with view
        public IActionResult Index()
        {
            var game = HttpContext.Session.GetObjectFromJson<TicTacToeGame>("Game") ?? new TicTacToeGame();
            HttpContext.Session.SetObjectAsJson("Game", game); // Ensure game is initialized
            return View(game);
        }

        // Action to handle player moves/choices
        [HttpPost]
        public IActionResult PlayTurn(int cell)
        {
            var game = HttpContext.Session.GetObjectFromJson<TicTacToeGame>("Game");

            if (game != null && !game.GameOver && game.Board[cell] == null)
            {
                game.Board[cell] = game.CurrentPlayer;

                if (game.CheckWinner())
                {
                    game.GameOver = true;
                }
                else if (!game.Board.Contains(null))
                {
                    game.GameOver = true;
                }
                else
                {
                    game.SwitchPlayer();
                }

                HttpContext.Session.SetObjectAsJson("Game", game);
            }

            return RedirectToAction("Index");
        }

        // After winner -> Loop ends and created option to restart
        public IActionResult NewGame()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
