﻿using OpenQA.Selenium;
using UserInterfaceTests.Pages.Locators;

namespace UserInterfaceTests.Pages
{
    internal class RepositoriesPage : RepsitoriesPageLocators
    {
        private readonly IWebDriver webDriver;

        public RepositoriesPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public NewRepositoryPage ClickToNewRepository()
        {
            Awaiter.Wait(webDriver, newRepositoryLocator);
            webDriver.FindElement(newRepositoryLocator).Click();

            return new NewRepositoryPage(webDriver);
        }
    }
}