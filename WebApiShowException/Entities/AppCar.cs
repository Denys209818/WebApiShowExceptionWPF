using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiShowException.Entities
{
    [Table("tblCars")]
    public class AppCar
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Mark { get; set; }
        [Required, StringLength(255)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public float Capacity { get; set; }
        [Required, StringLength(255)]
        public string Image { get; set; }
    }
}
