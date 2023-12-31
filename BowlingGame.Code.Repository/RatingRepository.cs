﻿using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Enums;
using BowlingGame.Core.Models;

namespace BowlingGame.Code.Repository;
public class RatingRepository : IRatingRepository
{
    public IEnumerable<IBowlerRating> GetRatings()
    {
        foreach (int key in Enum.GetValues(typeof(BowlerRating)))
        {
            string name = Enum.GetName(typeof(BowlerRating), key)!;

            yield return new BowlerRatingModel
            {
                Value = name,
                Key = key
            };
        }
    }
}
