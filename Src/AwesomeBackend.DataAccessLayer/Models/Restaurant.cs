using AwesomeBackend.Authentication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.DataAccessLayer.Models
{
    [Table("Restaurants")]
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        public Address Address { get; set; }

        [StringLength(30)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string WebSite { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
