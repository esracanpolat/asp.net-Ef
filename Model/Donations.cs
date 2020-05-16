using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Donations
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Adress { get; set; }

        public int Phone { get; set; }
        public string email { get; set; }
        public int age { get; set; }

        public string BloodGroup { get; set; }
    }
}
