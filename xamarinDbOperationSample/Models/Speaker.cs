using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xamarinDbOperationSample.Models
{
    public class Speaker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpeakerId { get; set; }

        [Required]
        public string SpeakerName { get; set; }

        //public virtual ICollection<Session>Sessions { get; set; }
    }
}