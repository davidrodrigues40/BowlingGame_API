﻿namespace BowlingGame.Core.Abstractions.Models;

public interface IGame
{
    IEnumerable<IBowler> Bowlers { get; set; }
    IScoreCard? Winner { get; set; }
}