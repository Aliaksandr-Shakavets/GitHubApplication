using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class RepositoryFormPageElements : BasePageElements
    {
        private readonly By repositoryNameInput = By.XPath("//input[@id='repository_name']");
        private readonly By repositoryDescriptionInput = By.XPath("//input[@id='repository_description']");
        private readonly By publicVisibilityRadioButton = By.XPath("//input[@id='repository_visibility_public']");
        private readonly By privateVisibilityRadioButton = By.XPath("//input[@id='repository_visibility_private']");
        private readonly By addReadmeRadioButton = By.XPath("//input[@id='repository_auto_init']");
        private readonly By addGitIgnoreRadioButton = By.XPath("//input[@id='repository_gitignore_template_toggle']");
        private readonly By gitIgnoreTemplateRadioButton = By.XPath("//i[text()='.gitignore template:']");
        private readonly By ignoreFilterInput = By.XPath("//input[@id='context-ignore-filter-field']");
        private readonly By submitButton = By.XPath("//button[@type='submit' and contains(text(),'Create repository')]");
        private readonly By unsuccessfulGitIgnoreResult = By.XPath("//div[@class='select-menu-no-results']");
        private readonly By repositoryNameInputCheker = By.XPath("//dd[contains(@id,'input-check')]");
        private readonly string suitableTemplateXpath = "//label[@class='select-menu-item']/child::span[text()='template']";

        public IWebElement GetNameInput() => webDriver.GetVisibleElement(repositoryNameInput);

        public IWebElement GetDescriptionInput() => webDriver.GetVisibleElement(repositoryDescriptionInput);

        public IWebElement GetPublicVisibilityButton() => webDriver.GetVisibleElement(publicVisibilityRadioButton);

        public IWebElement GetPrivateVisibilityButton() => webDriver.GetVisibleElement(privateVisibilityRadioButton);

        public IWebElement GetReadmeRadioButton()
        {
            webDriver.ScrollToBottom();
            return webDriver.GetVisibleElement(addReadmeRadioButton);
        }

        public IWebElement GetGitIgnoreButton() => webDriver.GetVisibleElement(addGitIgnoreRadioButton);

        public IWebElement GetGitIgnoreTeplateButton() => webDriver.GetVisibleElement(gitIgnoreTemplateRadioButton);

        public IWebElement GetIgnoreFilterInput() => webDriver.GetVisibleElement(ignoreFilterInput);

        public IWebElement GetSuitableTemplate(string ignoreFilter)
        {
            var templateXpath = suitableTemplateXpath.Replace("template", ignoreFilter, System.StringComparison.InvariantCultureIgnoreCase);

            return webDriver.GetVisibleElement(By.XPath(templateXpath));
        }

        public bool IsThereGitIgnoreResultList()
        {
            var isContainsTemplate = webDriver.FindElement(unsuccessfulGitIgnoreResult).GetCssValue("display") == "none";

            return isContainsTemplate;
        }

        public void CloseGitIgnoreMenu()
        {
            webDriver.ClickToUnclicableElement(GetGitIgnoreTeplateButton());
        }

        public IWebElement GetSubmitButton() => webDriver.GetVisibleElement(submitButton);

        public bool IsNameUnique()
        {
            var elementWithErrorClass = webDriver.GetVisibleElement(repositoryNameInputCheker);

            return elementWithErrorClass.GetAttribute("class") == "success";
        }
    }
}
