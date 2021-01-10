﻿using System.ComponentModel.DataAnnotations;

namespace AwesomeBackend.Shared.Models.Requests
{
    public class RatingRequest
    {
        [Range(1, 5)]
        public int Score { get; set; }

        public string Comment { get; set; }
    }
}
