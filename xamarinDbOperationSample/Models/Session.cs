using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace xamarinDbOperationSample.Models
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }

        [Required]
        public string SessionName { get; set; }

        [Required]
        public string Speaker { get; set; }

        [Required]
        public int HallId { get; set; }

        public virtual Hall Hall { get; set; }
    }
}