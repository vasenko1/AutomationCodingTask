using Amazon.AutomationTests.Base.PageObject.SearchResultPage;
using OpenQA.Selenium;

namespace Amazon.AutomationTests.Steps.Steps.SearchResultPageSteps
{
    public class SearchResultPageSteps : BaseSteps
    {
        private SearchResultPage _searchResultPage = new SearchResultPage();
        public SearchResultPageSteps(IWebDriver driver) : base(driver)
        {
        }

        public void ClickFirstResultCell()
        {
            Click(_searchResultPage.FirstCellTitle, "[Search result page] Clicked on the first result cell.");
            WaitForPageFullyLoaded();
        }
    }
}
