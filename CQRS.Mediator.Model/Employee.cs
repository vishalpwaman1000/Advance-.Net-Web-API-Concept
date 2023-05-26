using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediator.Model
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime InsertionDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public int Age { get; set; }
        /*public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }*/
    }

    public class fact_user_master
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public DateTime InsertionDate { get; set;} = DateTime.Now;

        [EmailAddress]
        public string EmailID { get; set; }
        
        public string Password { get; set; }

    }
}
