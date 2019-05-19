using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KariHotel.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Ім'я")]
        [RegularExpression(@"^[А-Я]+[а-яА-Я""'\s-]*$")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50)]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }
        [StringLength(50)]
        [Display(Name = "По-батькові")]
        [DisplayFormat(NullDisplayText = " ")]
        public string FirstMidName { get; set; }
        [Required]
        [Display(Name = "Контактний телефон")]
        public string ContactPhone { get; set; }
        [Required]
        [Display(Name = "Електронна адреса")]
        public string Email { get; set; }


        public ICollection<Orders> Order { get; set; }
    }
}
