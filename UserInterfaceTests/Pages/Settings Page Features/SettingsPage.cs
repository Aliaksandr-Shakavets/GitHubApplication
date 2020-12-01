using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class SettingsPage : Footer
    {
        private readonly SettingsPageElements pageElements = new SettingsPageElements();

        public ConfirmDeletePage DeleteThisRepository()
        {
            var deleteButton = pageElements.OptionsElements.GetDeleteRepositoryButton();
            deleteButton.Click();

            return new ConfirmDeletePage(pageElements.GetProjectNameElement().Text);
        }
    }
}