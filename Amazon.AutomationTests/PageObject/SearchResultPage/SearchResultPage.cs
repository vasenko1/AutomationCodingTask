using Amazon.AutomationTests.Base.PageObject.Base;
using OpenQA.Selenium;

namespace Amazon.AutomationTests.Base.PageObject.SearchResultPage
{
    public class SearchResultPage : BasePage
    {
        public By FirstCellTitle = By.CssSelector("div[data-cel-widget='search_result_1'] h2 span");
    }
}
