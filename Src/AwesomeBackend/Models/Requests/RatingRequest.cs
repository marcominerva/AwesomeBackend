using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.Models.Requests
{
    public class RatingRequest
    {
        [Range(1, 5)]
        public int Score { get; set; }

        public string Comment { get; set; }
    }
}
