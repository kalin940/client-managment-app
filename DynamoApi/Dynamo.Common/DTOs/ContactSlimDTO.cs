using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Common.DTOs
{
    public class ContactSlimDTO
    {
        public ContactSlimDTO()
        {

        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Number { get; set; } 
        public string Email { get; set; }
        public int CountryID { get; set; }
    }
}
