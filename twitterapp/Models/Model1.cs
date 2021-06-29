using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;


namespace twitterapp.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }

        public System.Data.Entity.DbSet<twitterapp.Models.user> users { get; set; }
        public System.Data.Entity.DbSet<twitterapp.Models.post> posts { get; set; }
        public System.Data.Entity.DbSet<twitterapp.Models.newpost> newposts { get; set; }
    }
}
