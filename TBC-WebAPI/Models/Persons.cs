using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webApi_test.Models
{
    public class Persons
    {
        public int ID { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public Gender GenderID { get; set; }
        [Required]
        public Status Status { get; set; }

    }

    public enum Gender
    {
        Male, Female
    }

    public enum Status : short
    {
        Active = 1,
        Inactive = 0
    }
}
