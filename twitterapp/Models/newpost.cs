using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace twitterapp.Models
{
    public class newpost
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Post { get; set; }
        public int UserId { get; set; }
        public user user { get; set; }
    }
}