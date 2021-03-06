﻿using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class ProjectFormPageElements : BasePageElements
    {
        private protected By boardNameLocator = By.XPath("//input[@id='project_name']");
        private protected By descriptionLocator = By.XPath("//textarea[@id='project_body']");
        private protected By publicProjectRadioButton = By.XPath("//input[@id='project_public_true']");
        private protected By privateProjectRadioButton = By.XPath("//input[@id='project_public_false']");
        private protected By submitButton = By.XPath("//button[@type='submit' and contains(text(),'Create project')]");

        public IWebElement GetProjectNameInput() => webDriver.GetVisibleElement(boardNameLocator);

        public IWebElement GetDescriptionNameInput() => webDriver.GetVisibleElement(descriptionLocator);

        public IWebElement GetPublicVisibilityButton()
        {
            webDriver.ScrollToBottom();

            return webDriver.GetVisibleElement(publicProjectRadioButton);
        }

        public IWebElement GetPrivateVisibilityButton()
        {
            webDriver.ScrollToBottom();

            return webDriver.GetVisibleElement(privateProjectRadioButton);
        }

        public IWebElement GetSubmitButton() => webDriver.GetVisibleElement(submitButton);
    }
}
