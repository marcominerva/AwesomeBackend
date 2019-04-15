﻿using AwesomeBackend.Authentication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.DataAccessLayer.Models
{
    [Table("Ratings")]
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid RestaurantId { get; set; }

        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        [Column("Rating")]
        public double Score { get; set; }

        public string Comment { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }
    }
}
