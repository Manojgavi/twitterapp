using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace twitterapp.Models
{
    public class post
    {
        public int Id { get; set; }
        
        public string Post { get; set; }

        //[ForeignKey("user")]
        public int UserId { get; set; }
        public user user { get; set; }
        
        
        
    }
}