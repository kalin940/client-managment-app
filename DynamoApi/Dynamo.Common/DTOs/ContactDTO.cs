using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dynamo.Common.DTOs
{
    public class ContactDTO
    {
        [Required]
        public int ID { get; set; }

        public int UserID { get; set; }

        public virtual UserDTO User { get; set; }

        [Required]
        [MaxLength(100)]
        public string Number { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
