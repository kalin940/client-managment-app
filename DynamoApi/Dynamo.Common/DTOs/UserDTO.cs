using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dynamo.Common.DTOs
{
    public class UserDTO
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int? Age { get; set; }

        public string Email { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public int CountryID { get; set; }

        public virtual CountryDTO Country { get; set; }

        public virtual ICollection<ContactDTO> Contacts { get; set; }
    }
}
