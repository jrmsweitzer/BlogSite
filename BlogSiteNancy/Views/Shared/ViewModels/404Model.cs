using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSiteNancy.Views.Shared.ViewModels
{
    public class _404Model
    {
        private string _defaultErrorMessage = "You have reached a 404 page!";
        private string _errorMessage;

        public _404Model(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public string ErrorMessage { get { return string.IsNullOrEmpty(_errorMessage) ? _defaultErrorMessage : _errorMessage; } }
    }
}