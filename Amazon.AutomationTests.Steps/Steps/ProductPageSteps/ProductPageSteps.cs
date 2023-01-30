using Amazon.AutomationTests.Base.PageObject.HomePage;
using OpenQA.Selenium;

namespace Amazon.AutomationTests.Steps.Steps.ProductPageSteps
{
    public class ProductPageSteps : BaseSteps
    {
        private ProductPage _productPage = new ProductPage();
        public ProductPageSteps(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAddToCartButton()
        {
            Click(_productPage.AddToCartButton, "[Product page] Clicked the 'Add to Cart' button.");
            WaitForPageFullyLoaded();
        }

        public void ChangeProductQuantityTo(int newQuantity)
        {
            By quantityOptions = By.CssSelector($"#quantity>option[value='{newQuantity}']");
            Click(_productPage.QuantityDropdown);
            Click(quantityOptions, $"[Product page] Product Quantity is changed to '{newQuantity}'.");
            WaitForPageFullyLoaded();
        }

        public void ClickCartButton()
        {
            Click(_productPage.CartButton, "[Product page] Clicked the 'Cart' button.");
            WaitForPageFullyLoaded();
        }
    }
}
