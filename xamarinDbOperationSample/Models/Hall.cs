﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xamarinDbOperationSample.Models
{
    public class Hall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HallId { get; set; }

        [Required]
        public string HallName { get; set; }

        //public virtual ICollection<Session> Sessions { get; set; }
    }
}