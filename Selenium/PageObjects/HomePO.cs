using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.PageObjects.Base;

namespace Selenium.PageObjects
{
    public class HomePO : Layout
    {
        public HomePO(IWebDriver driver)
            : base(driver)
        {
            _url = "http://potpourriblogs.gear.host/";
            GoTo(_url);
        }
    }
}
