using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediator.Model
{
    public class InsertRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,100)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone] 
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings =true)]
        public string? Address { get; set; }

    }


    public class UpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
