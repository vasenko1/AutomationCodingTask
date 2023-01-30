using Amazon.AutomationTests.Base;
using Amazon.AutomationTests.Steps.Steps.CartPageSteps;
using Amazon.AutomationTests.Steps.Steps.HomePageSteps;
using Amazon.AutomationTests.Steps.Steps.ProductPageSteps;
using Amazon.AutomationTests.Steps.Steps.SearchResultPageSteps;
using Amazon.AutomationTests.Tests.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Amazon.AutomationTests.Tests.Tests
{
    public class BaseTest
    {
        private IConfiguration _configuration;


        [OneTimeSetUp]
        public void BeforeClass()
        {
            _configuration = SettingsHelper.InitConfiguration();
        }

        [SetUp]
        public void BeforeTests()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton(new BaseDriver().InitChrome());
            services.InitUrlSettings(_configuration);
            services.AddSingleton<HomePageSteps>();
            services.AddSingleton<SearchResultPageSteps>();
            services.AddSingleton<ProductPageSteps>();
            services.AddSingleton<CartPageSteps>();
            ContainerHelper.ServiceProvider = services.BuildServiceProvider();
        }
        
        [TearDown]
        public void AfterTest()
        {
            IWebDriver driver = ContainerHelper.ServiceProvider.GetRequiredService<IWebDriver>();
            if (driver != null)
                driver.Quit();
            Console.WriteLine("Browser is closed.");
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
        }
    }
}
