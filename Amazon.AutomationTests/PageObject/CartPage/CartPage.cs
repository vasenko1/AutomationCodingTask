using Amazon.AutomationTests.Base.PageObject.Base;
using OpenQA.Selenium;

namespace Amazon.AutomationTests.Base.PageObject.CartPage
{
    public class CartPage : BasePage
    {
        public By QuantityDropdown = By.ClassName("quantity");
        public By ProductPrice = By.ClassName("sc-product-price");
        public By ProductSubtotalPrice = By.CssSelector("#sc-subtotal-amount-activecart>span");
        public By ProductSubtotalQuantity = By.Id("sc-subtotal-label-activecart");
    }
}
