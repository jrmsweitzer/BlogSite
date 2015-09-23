using System;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.Framework.Exceptions
{
    [Serializable]
    public class WrongPageException : Exception
    {
        public WrongPageException()
            : base() { }

        public WrongPageException(string message)
            : base(message) { }
    }
}
