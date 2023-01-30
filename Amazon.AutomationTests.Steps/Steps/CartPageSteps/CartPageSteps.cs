using Amazon.AutomationTests.Base.PageObject.CartPage;
using OpenQA.Selenium;
using System.Globalization;

namespace Amazon.AutomationTests.Steps.Steps.CartPageSteps
{
    public class CartPageSteps : BaseSteps
    {
        private CartPage cartPage = new CartPage();
        public CartPageSteps(IWebDriver driver) : base(driver)
        {
        }

        public void ChangeProductQuantityTo(int newQuantity)
        {
            By quantityOptions = By.CssSelector($"#quantity>option[value='{newQuantity}']");
            Click(cartPage.QuantityDropdown);
            Click(quantityOptions, $"[Cart page] Product Quantity is changed to '{newQuantity}'.");
            WaitForPageFullyLoaded();
            RefreshPage();
        }

        public double GetProductPrice()
        {
            string price = GetText(cartPage.ProductPrice);
            string cleanString = TrimPriceSign(price);
            Console.WriteLine($"[Cart page] The product Price is '{cleanString}'.");
            return double.Parse(cleanString, CultureInfo.InvariantCulture);
        }

        public double GetProductSubtotalPrice()
        {

            string price = GetText(cartPage.ProductSubtotalPrice);
            string cleanString = TrimPriceSign(price);
            Console.WriteLine($"[Cart page] The product subtotal Price is '{cleanString}'.");
            return double.Parse(cleanString, CultureInfo.InvariantCulture);
        }

        public int GetProductSubtotalQuantity()
        {
            string initialText = GetText(cartPage.ProductSubtotalQuantity);
            Console.WriteLine($"[Cart page] The product Quantity {initialText.ToLower()}");
            return Int32.Parse(SplitSubtotalQuantityText(initialText));
        }

        private string TrimPriceSign(String price)
        {
            char[] charsToTrim = { '$', '£', '€' };
            return price.Trim(charsToTrim);
        }

        private string SplitSubtotalQuantityText(String subtotalQuantity)
        {
            string[] subs = subtotalQuantity.Split(' ', '(');
            return subs[2];
        }
    }
}
