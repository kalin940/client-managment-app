using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Common.Exceptions
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException() : base() { }
        public ContactNotFoundException(string message) : base(message) { }
    }
}
