﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace xamarinDbOperationAPI.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class Hall
    {
        /// <summary>
        /// Initializes a new instance of the Hall class.
        /// </summary>
        public Hall() { }

        /// <summary>
        /// Initializes a new instance of the Hall class.
        /// </summary>
        public Hall(string hallName, int? hallId = default(int?))
        {
            HallId = hallId;
            HallName = hallName;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "HallId")]
        public int? HallId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "HallName")]
        public string HallName { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (HallName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "HallName");
            }
        }
    }
}
