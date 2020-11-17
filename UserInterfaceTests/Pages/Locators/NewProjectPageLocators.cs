using OpenQA.Selenium;

namespace UserInterfaceTests.Pages.Locators
{
    internal class NewProjectPageLocators
    {
        private protected By boardNameLocator = By.XPath("//input[@id='project_name']");
        private protected By descriptionLocator = By.XPath("//textarea[@id='project_body']");
        private protected By publicProjectRadioLocator = By.XPath("//input[@id='project_public_true']");
        private protected By submitButton = By.XPath("//button[@type='submit' and contains(text(),'Create project')]");
    }
}
