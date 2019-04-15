using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.BusinessLayer.Models
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
