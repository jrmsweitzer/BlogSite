using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.PageObjects.Base;
using Utilities;

namespace Selenium.PageObjects
{
    public class HomePageObject : LayoutPageObject
    {
        public HomePageObject(IWebDriver driver)
            : base(driver)
        {
            _url = Constants.Urls.Home;
            GoTo(_url);
        }
    }
}
