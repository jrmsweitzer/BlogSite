using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSiteNancy.Utils
{
    public class Validatable
    {
        private IList<ValidationFailure> _failures = new List<ValidationFailure>();
        public IList<ValidationFailure> Failures { get { return _failures; } set { _failures = value; } }
        private IList<string> _successes = new List<string>();
        public IList<string> Successes { get { return _successes; } set { _successes = value; } }
    }
}