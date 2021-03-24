using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dynamo.Core.Db
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [Required]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        [Required]
        [StringLength(100)]
        public string Number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateModified { get; set; }
    }
}
