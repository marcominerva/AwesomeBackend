using AwesomeBackend.Common.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace AwesomeBackend.Common.Models.Requests.V2
{
    public class RatingRequest
    {
        [Range(1, 5)]
        public int Score { get; set; }

        public string Comment { get; set; }

        [NotFutureDate("2000-01-01")]
        public DateTime VisitedAt { get; set; }
    }
}
