using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class RepositoryFormPage : Footer
    {
        private readonly RepositoryFormPageElements pageElements = new RepositoryFormPageElements();

        public RepositoryFormPage SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentException($"'{nameof(name)}' cannot be null or empty", nameof(name));
            }

            var nameInput = pageElements.GetNameInput();
            nameInput.SendKeys(name);

            return this;
        }

        public RepositoryFormPage SetDescriptions(string descriptions)
        {
            if (!string.IsNullOrEmpty(descriptions))
            {
                var descriptionInput = pageElements.GetDescriptionInput();
                descriptionInput.SendKeys(descriptions);
            }

            return this;
        }

        public RepositoryFormPage SetVisibility(bool isPublic = true)
        {
            var radioButton = pageElements.GetPublicVisibilitryButton();
            if (!isPublic)
            {
                radioButton = pageElements.GetPrivateVisibilitryButton();
            }

            radioButton.Click();

            return this;
        }

        public RepositoryFormPage AddReadmeRadioButton()
        {
            var radioButton = pageElements.GetReadmeRadioButton();
            radioButton.Click();

            return this;
        }

        public RepositoryFormPage AddGitIgnore()
        {
            var radioButton = pageElements.GetGitIgnoreButton();
            radioButton.Click();

            return this;
        }

        public RepositoryFormPage AddGitIgnoreTemplate()
        {
            var radioButton = pageElements.GetGitIgnoreTeplateButton();
            radioButton.Click();

            return this;
        }

        public RepositoryFormPage SetIgnoreFilter(string ignoreFilter)
        {
            if (string.IsNullOrEmpty(ignoreFilter))
            {
                throw new System.ArgumentException($"'{nameof(ignoreFilter)}' cannot be null or empty", nameof(ignoreFilter));
            }

            var ignoreInput = pageElements.GetIgnoreFilterInput();
            ignoreInput.SendKeys(ignoreFilter);

            SelectTemplate(ignoreFilter);

            return this;
        }

        public RepositoriesPage Submit()
        {
            var submitButton = pageElements.GetSubmitButton();
            submitButton.Click();

            return new RepositoriesPage();
        }

        private void SelectTemplate(string ignoreFilter) => pageElements.GetSuitableTemplate(ignoreFilter).Click();
    }
}
