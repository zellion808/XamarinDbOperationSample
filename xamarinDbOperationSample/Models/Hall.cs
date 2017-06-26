using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace xamarinDbOperationSample.Models
{
    public class Hall
    {
        [Key]
        public int HallId { get; set; }

        [Required]
        public string HallName { get; set; }

        // public virtual ICollection<Session> Sessions { get; set; }
    }
}