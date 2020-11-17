using OpenQA.Selenium;

namespace UserInterfaceTests.Pages.Locators
{
    internal class NewRepositoryPageLocators
    {
        private protected readonly By repositoryNameInput = By.XPath("//input[@id='repository_name']");
        private protected readonly By repositoryDescriptionInput = By.XPath("//input[@id='repository_description']");
        private protected readonly By publicVisibilityRadioButton = By.XPath("//input[@id='repository_visibility_public']");
        private protected readonly By privateVisibilityRadioButton = By.XPath("//input[@id='repository_visibility_private']");
        private protected readonly By addReadmeRadioButton = By.XPath("//input[@id='repository_auto_init']");
        private protected readonly By addGitIgnoreRadioButton = By.XPath("//input[@id='repository_gitignore_template_toggle']");
        private protected readonly By gitIgnoreTemplateLocator = By.XPath("//i[text()='.gitignore template:']");
        private protected readonly By ignoreFilterLocator = By.XPath("//input[@id='context-ignore-filter-field']");
        private protected readonly By submitButton = By.XPath("//button[@type='submit' and contains(text(),'Create repository')]");
    }
}
