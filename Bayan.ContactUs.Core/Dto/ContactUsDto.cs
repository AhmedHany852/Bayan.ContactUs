using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bayan.ContactUs.Core.Dto
{
    public class ContactUsDto
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
