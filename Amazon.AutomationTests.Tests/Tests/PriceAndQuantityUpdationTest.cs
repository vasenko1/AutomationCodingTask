using Amazon.AutomationTests.Steps.Steps.CartPageSteps;
using Amazon.AutomationTests.Steps.Steps.HomePageSteps;
using Amazon.AutomationTests.Steps.Steps.ProductPageSteps;
using Amazon.AutomationTests.Steps.Steps.SearchResultPageSteps;
using Amazon.AutomationTests.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Amazon.AutomationTests.Tests.Tests
{
    public class PriceAndQuantityUpdationTest : BaseTest
    {
        [Test, Description("Check if a product Price and Quantity are updated properly")]
        [Category("SimpleTest")]
        [TestCase("hat for man", 2, 1)]
        public void CheckProductPriceAndQuantity(String textForSearch, int initialQuantity, int newQuantity)
        {
            //Arrange
            var homePageSteps = ContainerHelper.ServiceProvider.GetRequiredService<HomePageSteps>();
            var searchResultPageSteps = ContainerHelper.ServiceProvider.GetRequiredService<SearchResultPageSteps>();
            var productPageSteps = ContainerHelper.ServiceProvider.GetRequiredService<ProductPageSteps>();
            var cartPageSteps = ContainerHelper.ServiceProvider.GetRequiredService<CartPageSteps>();
            //Act
            homePageSteps.OpenHomePage();
            homePageSteps.ClickAcceptAllCookies();
            homePageSteps.SearchProductByText(textForSearch);
            searchResultPageSteps.ClickFirstResultCell();
            productPageSteps.ChangeProductQuantityTo(initialQuantity);
            productPageSteps.ClickAddToCartButton();
            productPageSteps.ClickCartButton();
            double price = cartPageSteps.GetProductPrice();
            double subtotalPrice = cartPageSteps.GetProductSubtotalPrice();
            int initialSubtotalQuantity = cartPageSteps.GetProductSubtotalQuantity();
            //Assert
            Assert.That(subtotalPrice / initialQuantity, Is.EqualTo(price), $"Expected to be the same value ({price}).");
            Assert.That(initialSubtotalQuantity, Is.EqualTo(initialQuantity), $"Expected to be the same quantity ({initialQuantity}).");
            cartPageSteps.ChangeProductQuantityTo(newQuantity);
            double newSubtotalPrice = cartPageSteps.GetProductSubtotalPrice();
            int newSubtotalQuantity = cartPageSteps.GetProductSubtotalQuantity();
            Assert.That(newSubtotalPrice / newQuantity, Is.EqualTo(price), $"Expected to be the same value ({price}).");
            Assert.That(newSubtotalQuantity, Is.EqualTo(newQuantity), $"Expected to be the same value ({newQuantity}).");
        }
    }
}
