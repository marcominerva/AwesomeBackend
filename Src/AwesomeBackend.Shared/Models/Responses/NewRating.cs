using System;

namespace AwesomeBackend.Shared.Models.Responses
{
    public class NewRating
    {
        public Guid RestaurantId { get; }

        public double AverageScore { get; }

        public NewRating(Guid restaurantId, double averageScore)
        {
            RestaurantId = restaurantId;
            AverageScore = averageScore;
        }
    }
}
