using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KariHotel.Models
{
    public class Room
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }
        [Required]
        [Display(Name = "Опис")]
        public string Title { get; set; }
        [Display(Name = "Номер")]
        [DisplayFormat(NullDisplayText = "Засекречено")]
        public int Number { get; set; }

        public ICollection<Orders> Order { get; set; }
    }
}
