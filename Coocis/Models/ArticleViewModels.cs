using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Coocis.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string Author { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Release")]
        public DateTime ReleaseDateTime { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
    }

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ArticleDBContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public ArticleDBContext() : base("name=MySqlConnection")
        {
            Database.SetInitializer<ArticleDBContext>(new DropCreateDatabaseAlways<ArticleDBContext>());
        }
    }
}