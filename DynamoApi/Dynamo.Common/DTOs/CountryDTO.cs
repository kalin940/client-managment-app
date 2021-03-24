using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dynamo.Common.DTOs
{
    public class CountryDTO
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string CountryCode { get; set; }
    }
}
