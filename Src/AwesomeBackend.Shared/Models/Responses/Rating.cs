using System;

namespace AwesomeBackend.Shared.Models.Responses
{
    public class Rating
    {
        public Guid Id { get; set; }

        public double RatingScore { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public string User { get; set; }
    }
}
