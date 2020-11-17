using OpenQA.Selenium;
using TestsFeatures;
using UserInterfaceTests.Pages.Locators;

namespace UserInterfaceTests.Pages
{
    internal class NewRepositoryPage : NewRepositoryPageLocators
    {
        private readonly IWebDriver webDriver;

        public NewRepositoryPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void CreateNewRepository(bool isPublicVisibility = true, bool needAddReadme = true, string gitIgnoreTemplate = "none")
        {
            SetRepositoyName();
            SetRepositoryDescription();
            SetVisibility(isPublicVisibility);

            if (needAddReadme)
            {
                AddReadmeFile();
            }

            if (gitIgnoreTemplate != "none")
            {
                ScrollToBottom();
                AddGitIgnoreTemplate(gitIgnoreTemplate);
            }

            Submit();
        }

        private void Submit()
        {
            ScrollToBottom();
            Awaiter.Wait(webDriver, submitButton);
            webDriver.FindElement(submitButton).Click();
        }

        private void AddGitIgnoreTemplate(string gitIgnoreTemplate)
        {
            Awaiter.Wait(webDriver, addGitIgnoreRadioButton);
            webDriver.FindElement(addGitIgnoreRadioButton).Click();

            Awaiter.Wait(webDriver, gitIgnoreTemplateLocator);
            webDriver.FindElement(gitIgnoreTemplateLocator).Click();

            Awaiter.Wait(webDriver, ignoreFilterLocator);
            webDriver.FindElement(ignoreFilterLocator).SendKeys(gitIgnoreTemplate);

            var existTemplate = By.XPath($"//label[@class='select-menu-item']/child::span[text()='{gitIgnoreTemplate}']");
            webDriver.FindElement(existTemplate).Click();
        }

        private void AddReadmeFile()
        {
            Awaiter.Wait(webDriver, addReadmeRadioButton);
            webDriver.FindElement(addReadmeRadioButton).Click();
        }

        private void SetVisibility(bool isPublicvisibility)
        {
            var webElement = isPublicvisibility ? publicVisibilityRadioButton : privateVisibilityRadioButton;
            Awaiter.Wait(webDriver, webElement);
            webDriver.FindElement(webElement).Click();
        }

        private void SetRepositoryDescription()
        {
            Awaiter.Wait(webDriver, repositoryDescriptionInput);
            webDriver.FindElement(repositoryDescriptionInput).SendKeys(TestHelper.GetRandomString(120));
        }

        private void SetRepositoyName()
        {
            Awaiter.Wait(webDriver, repositoryNameInput);
            webDriver.FindElement(repositoryNameInput).SendKeys(TestHelper.GetRandomString(12));
        }

        private void ScrollToBottom()
        {
            var jsExecutable = "window.scrollTo(0, document.body.scrollHeight);";
            (webDriver as IJavaScriptExecutor).ExecuteScript(jsExecutable);
        }
    }
}
