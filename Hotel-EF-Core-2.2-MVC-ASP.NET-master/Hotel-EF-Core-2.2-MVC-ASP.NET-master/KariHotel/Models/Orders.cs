using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KariHotel.Models
{
    public class Orders
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Номер замовлення")]
        public int OrderID { get; set; }

        [Display(Name = "Номер клієнта")]
        public int ClientID { get; set; }
        [Display(Name = "Номер кімнати")]
        public int RoomID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата заїзду")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Check_inDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата виїзду")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Check_outDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата замовлення")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        public Client Client { get; set; }
        public Room Room { get; set; }
        public ICollection<OddServ> OddServ { get; set; }
        public ICollection<Fines> Fines { get; set; }
    }
}
