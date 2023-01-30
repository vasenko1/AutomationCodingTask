using Amazon.AutomationTests.Base.PageObject.HomePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Amazon.AutomationTests.Steps.Steps
{
    public class BaseSteps
    {
        protected IWebDriver driver;
        private int _secondsToWait = 15;
        private HomePage _homePage = new HomePage();

        public BaseSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWait<IWebDriver> GetWait()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(_secondsToWait));
        }

        public void WaitForPageFullyLoaded()
        {
            GetWait().Until(d => ((IJavaScriptExecutor)d).ExecuteScript(
                "return document.readyState !== 'loading'"));
        }

        protected void WaitForElementDisplayed(By elementWaitFor)
        {
            try
            {
                IWait<IWebDriver> wait = GetWait();
                wait.Until(driver => driver.FindElement(elementWaitFor).Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! Can't find element: " + elementWaitFor.ToString());
                throw new Exception($"{elementWaitFor} {e}");
            }
        }

        protected void Click(By by, String? description = null)
        {
            WaitForElementDisplayed(by);
            driver.FindElement(by).Click();
            Console.WriteLine(description);
        }

        protected void TypeText(By fieldLocator, String text, String? description = null)
        {
            WaitForElementDisplayed(fieldLocator);
            driver.FindElement(fieldLocator).SendKeys(text);
            Console.WriteLine(description);
        }

        protected String GetText(By by)
        {
            WaitForElementDisplayed(by);
            return driver.FindElement(by).Text;
        }

        public void SearchProductByText(String searchText)
        {
            TypeText(_homePage.SearchField, searchText);
            TypeText(_homePage.SearchField, Keys.Enter, $"Searching products by text '{searchText}'.");
            WaitForPageFullyLoaded();
        }

        public void ClickAcceptAllCookies()
        {
            Click(_homePage.AcceptCookiesButton, "The 'AcceptCookies' button is cklicked on a Popup.");
        }

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
            WaitForPageFullyLoaded();
            Console.WriteLine("The page reloaded.");
        }
    }
}
