using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xamarinDbOperationSample.Models
{
    public class ParticipatingSession
    {
        [Key]
        [Column(Order = 1)]
        public int RegistersId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int SessionId { get; set; }

        [Required]
        public int HallId { get; set; }
    }
}