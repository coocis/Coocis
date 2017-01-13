using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Coocis.Models
{
    public class NATTraversalModels
    {
        public int ID { get; set; }
        public string ServerName { get; set; }
        public string ServiceAddress { get; set; }
    }

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class NATTraversalDBContext : DbContext
    {
        public DbSet<NATTraversalModels> Articles { get; set; }

        public NATTraversalDBContext() : base("name=MySqlConnection")
        {
            //ApplicationDbContext.Create();
            Database.SetInitializer<NATTraversalDBContext>(new DropCreateDatabaseAlways<NATTraversalDBContext>());
        }
    }
}