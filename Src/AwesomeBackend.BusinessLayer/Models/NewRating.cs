using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.BusinessLayer.Models
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
