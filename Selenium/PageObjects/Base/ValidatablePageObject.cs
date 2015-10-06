using OpenQA.Selenium;
using Selenium.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.PageObjects.Base
{
    public class ValidatablePageObject : Layout
    {
        public ValidatablePageObject(IWebDriver driver) : base(driver)
        {
            // DO NOTHING
        }

        // Locators
        public static readonly By Errors = By.Id("Error");
        public static readonly ByFormatter Error = ByFormatter.XPath("//label[@id='Error'][contains(.,\"{0}\")]");
        public static readonly By Successes = By.Id("Success");
        public static readonly ByFormatter Success = ByFormatter.XPath("//label[@id='Success'][contains(.,\"{0}\")]");

        // Logic

        /// <summary>
        /// Returns whether a specific error exists on the page.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public bool IsErrorPresent(string errorMessage)
        {
            return ElementExists(Error.Format(errorMessage));
        }

        /// <summary>
        /// Returns the number of errors on a given page.
        /// </summary>
        /// <returns></returns>
        public int GetErrorCount()
        {
            return FindAll(Errors).Count;
        }

        /// <summary>
        /// Returns whether a specific success message exists on the page.
        /// </summary>
        /// <returns></returns>
        public bool IsSuccessMessagePresent(string successMessage)
        {
            return ElementExists(Success.Format(successMessage));
        }

        /// <summary>
        /// Returns the number of success messages on a given page.
        /// </summary>
        /// <returns></returns>
        public int GetSuccessCount()
        {
            return FindAll(Successes).Count;
        }
    }
}
