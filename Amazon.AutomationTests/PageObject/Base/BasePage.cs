using OpenQA.Selenium;

namespace Amazon.AutomationTests.Base.PageObject.Base
{
    public class BasePage
    {
        public By AcceptCookiesButton = By.Id("sp-cc-accept");
        
        #region HeaderMenu
        public By SearchField = By.Id("twotabsearchtextbox");
        public By CartButton = By.Id("nav-cart-count-container");
        #endregion
    }
}
