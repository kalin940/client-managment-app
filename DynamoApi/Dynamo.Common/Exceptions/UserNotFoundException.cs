using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Common.Exceptions
{
    public  class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base() { }
        public UserNotFoundException(string message) : base(message) { }
    }
}
