using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class Wydarzenia
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        [StringLength(40, ErrorMessage = "Max 40 znaków")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Proszę wypełnić pole.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime WhenHappens { get; set; }
    }
}
