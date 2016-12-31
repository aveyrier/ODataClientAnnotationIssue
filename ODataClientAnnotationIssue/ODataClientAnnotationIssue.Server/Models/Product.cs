using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ODataClientAnnotationIssue.Server.Models
{
    public class Product
    {
        [Key]
        public Guid Key { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}