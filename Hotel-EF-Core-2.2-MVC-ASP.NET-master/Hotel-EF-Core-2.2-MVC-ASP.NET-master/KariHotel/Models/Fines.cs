using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KariHotel.Models
{
    public class Fines
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FinesID { get; set; }
        
        [Required]
        [Display(Name = "Назва")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ціна")]
        public int Price { get; set; }
        
    }
}
