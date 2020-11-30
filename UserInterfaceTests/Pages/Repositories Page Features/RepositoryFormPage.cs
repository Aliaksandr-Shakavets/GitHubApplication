using OpenQA.Selenium;
using System.Linq;
using Tests.Core.Data_access_layer;
using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class RepositoryFormPage : Footer
    {
        private readonly RepositoryFormPageElements pageElements = new RepositoryFormPageElements();
        private readonly RepositoryFormInfo form;

        public RepositoryFormPage(RepositoryFormInfo repositoryForm)
        {
            form = repositoryForm ?? throw new System.ArgumentNullException(nameof(repositoryForm));
        }

        public RepositoryFormPage SetName()
        {
            string name = form.Name;
            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentException($"Repository name can not be null or empty.", name);
            }

            var nameInput = pageElements.GetNameInput();
            nameInput.SendKeys(form.Name);

            if (!pageElements.IsNameUnique())
            {
                throw new System.ArgumentException($"Project '{form.Name}' already exists on this account.");
            }

            return this;
        }

        public RepositoryFormPage SetDescriptions()
        {
            string descriptions = form.Description;
            if (!string.IsNullOrEmpty(descriptions))
            {
                var descriptionInput = pageElements.GetDescriptionInput();
                descriptionInput.SendKeys(descriptions);
            }

            return this;
        }

        public RepositoryFormPage SetVisibility()
        {
            var radioButton = form.RepositoryVisibility switch
            {
                Visibility.Public => pageElements.GetPublicVisibilityButton(),
                Visibility.Private => pageElements.GetPrivateVisibilityButton(),
                _ => throw new System.NotImplementedException()
            };

            radioButton.Click();

            return this;
        }

        public RepositoryFormPage AddReadmeRadioButton()
        {
            if (!form.NeedToAddReadmi)
            {
                throw new System.InvalidOperationException("Repository form has not indicator to add the readmi file.");
            }

            var radioButton = pageElements.GetReadmeRadioButton();
            radioButton.Click();

            return this;
        }

        public RepositoryFormPage AddGitIgnore()
        {
            if (!form.NeedToAddGitIgnore)
            {
                throw new System.InvalidOperationException("Repository form has not indicator to add the git ignore.");
            }

            var radioButton = pageElements.GetGitIgnoreButton();
            radioButton.Click();

            AddGitIgnoreTemplate();
            SetIgnoreFilter();

            return this;
        }

        public RepositoryPageView Submit()
        {
            var submitButton = pageElements.GetSubmitButton();
            submitButton.Click();

            return new RepositoryPageView();
        }

        private void SelectTemplate(string ignoreFilter)
        {
            if (pageElements.IsThereGitIgnoreResultList())
            {
                pageElements.GetSuitableTemplate(ignoreFilter).Click();
            }
            else
            {
                pageElements.CloseGitIgnoreMenu();
                throw new NoSuchElementException($"Git ignore template list does not contains '{ignoreFilter}' filter.");
            }
        }

        private void AddGitIgnoreTemplate()
        {
            var radioButton = pageElements.GetGitIgnoreTeplateButton();
            radioButton.Click();
        }

        private void SetIgnoreFilter()
        {
            string ignoreFilter = form.GitIgnoreTemplate;
            if (string.IsNullOrEmpty(ignoreFilter))
            {
                throw new System.ArgumentException($"Ignore template cannot be null or empty.", ignoreFilter);
            }

            var ignoreInput = pageElements.GetIgnoreFilterInput();
            ignoreInput.SendKeys(ignoreFilter);

            SelectTemplate(ignoreFilter);
        }
    }
}
