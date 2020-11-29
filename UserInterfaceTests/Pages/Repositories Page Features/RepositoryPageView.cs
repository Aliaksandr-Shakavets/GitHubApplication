using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class RepositoryPageView
    {
        private readonly RepositoryPageViewElements pageElements = new RepositoryPageViewElements();

        public SettingsPage JumpToSettings()
        {
            var settingsButton = pageElements.GetSettingsButton();
            settingsButton.Click();

            return new SettingsPage();
        }

    }
}
