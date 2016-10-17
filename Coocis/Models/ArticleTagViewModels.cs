using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Coocis.Models
{
    public class ArticleTag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UsedCount { get; set; }
    }
}