using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace twitterapp.Models
{
    public class user
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        
    }
}