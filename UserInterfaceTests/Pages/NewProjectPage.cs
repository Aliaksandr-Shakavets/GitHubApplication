using OpenQA.Selenium;
using TestsFeatures;
using UserInterfaceTests.Pages.Locators;

namespace UserInterfaceTests.Pages
{
    internal class NewProjectPage : NewProjectPageLocators
    {
        private readonly IWebDriver webDriver;

        public NewProjectPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void CreateNewProject(bool canBeProjectNameIsEmpty = false)
        {
            var projectName = canBeProjectNameIsEmpty ? string.Empty : TestHelper.GetRandomString(10);

            SetProjectName(projectName);
            SetDescription();
            SetProjectPublicVisibility();
            Submit();
        }

        private void SetProjectName(string projectName)
        {
            Awaiter.Wait(webDriver, boardNameLocator);
            webDriver.FindElement(boardNameLocator)
                .SendKeys(projectName);
        }

        private void SetDescription()
        {
            Awaiter.Wait(webDriver, descriptionLocator);
            webDriver.FindElement(descriptionLocator)
               .SendKeys(TestHelper.GetRandomString(40));
        }

        private void SetProjectPublicVisibility()
        {
            ScrollToBottom();
            Awaiter.Wait(webDriver, publicProjectRadioLocator);
            webDriver.FindElement(publicProjectRadioLocator).Click();
        }

        private void ScrollToBottom()
        {
            var jsExecutable = "window.scrollTo(0, document.body.scrollHeight);";
            (webDriver as IJavaScriptExecutor).ExecuteScript(jsExecutable);
        }

        private void Submit()
        {
            Awaiter.Wait(webDriver, submitButton);
            var button = webDriver.FindElement(submitButton);
            if (!button.Enabled)
            {
                throw new NoSuchElementException($"{nameof(submitButton)} is disabled.");
            }

            button.Click();
        }
    }
}