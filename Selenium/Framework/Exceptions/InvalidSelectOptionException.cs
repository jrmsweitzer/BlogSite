using System;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.Framework.Exceptions
{
    [Serializable]
    public class InvalidSelectOptionException : Exception
    {
        public InvalidSelectOptionException()
            : base() { }

        public InvalidSelectOptionException(string message)
            : base(message) { }
    }
}
