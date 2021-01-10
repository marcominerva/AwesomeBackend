using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeBackend.DataAccessLayer.Entities
{
    [ComplexType]
    public class Address
    {
        [Required]
        [MaxLength(5)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(60)]
        public string Location { get; set; }

        [Required]
        [StringLength(30)]
        public string Province { get; set; }
    }
}
