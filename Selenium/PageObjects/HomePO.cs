using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.PageObjects.Base;
using Utilities;

namespace Selenium.PageObjects
{
    public class HomePO : Layout
    {
        public HomePO(IWebDriver driver)
            : base(driver)
        {
            _url = Constants.Urls.Home;
            GoTo(_url);
        }
    }
}
