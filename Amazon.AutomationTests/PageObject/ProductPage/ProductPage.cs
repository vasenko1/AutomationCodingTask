using Amazon.AutomationTests.Base.PageObject.Base;
using OpenQA.Selenium;

namespace Amazon.AutomationTests.Base.PageObject.HomePage
{
    public class ProductPage : BasePage
    {
        public By AddToCartButton = By.Id("add-to-cart-button");
        public By QuantityDropdown = By.Id("quantity");
    }
}
