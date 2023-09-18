﻿using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BowlingGame.Controllers
{
	[Route("api/")]
	[ApiController]
	public class BowlController : ControllerBase
	{
		private readonly IGameService _gameService;
        private readonly IRatedGameService _ratedGameService;

        public BowlController(IGameService gameService, IRatedGameService ratedGameService)
		{
			_gameService = gameService;
            _ratedGameService = ratedGameService;
        }

		[HttpPost]
		[Route("game")]
		[ProducesResponseType(typeof(Game<Bowler>), 200)]		
		public IActionResult Bowl(List<Player> players)
		{
			if (players == null || players.Count == 0)
				return BowlGame();

			List<Bowler> bowlers = new ();
			foreach (var player in players)
			{
                // add player to game
				bowlers.Add( new Bowler() {  Name = player.Name });
            }

			Game<IBowler> game =(Game<IBowler>)_gameService.NewGame(bowlers);
			game = (Game<IBowler>)_gameService.PlayGame(game);

			return Ok(game);
		}

        [HttpPost]
		[Route("game-rated")]
        [ProducesResponseType(typeof(Game<RatedBowler>), 200)]
        public IActionResult RatedBowl(List<RatedPlayer> players)
        {
            if (players == null || players.Count == 0)
                return BowlGame();

            List<RatedBowler> bowlers = new();
            foreach (var player in players)
            {
                // add player to game
                bowlers.Add(new RatedBowler() { Name = player.Name, Rating = player.Rating });
            }

            IGame<IRatedBowler> game = (Game<IRatedBowler>)_ratedGameService.NewGame(bowlers);
            game = _ratedGameService.PlayGame(game);

            return Ok(game);
        }

        private IActionResult BowlGame()
		{
			Bowler bowler1 = new() { Name = "Bowler 1" };

			IGame<IBowler> game = _gameService.NewGame(new List<IBowler> { bowler1 });

			return Ok(_gameService.PlayGame(game));
		}
    }
}