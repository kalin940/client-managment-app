using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;

namespace Dynamo.Core.Db
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? Age { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateModified { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public int CountryID { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
