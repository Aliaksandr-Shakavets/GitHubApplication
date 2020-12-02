using Tests.Core.Data_access_layer;
using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class ProjectFormPage : Footer
    {
        private readonly ProjectFormPageElements pageElements = new ProjectFormPageElements();
        private readonly ProjectFormInfo form;

        public ProjectFormPage(ProjectFormInfo form)
        {
            this.form = form ?? throw new System.ArgumentNullException(nameof(form));
        }

        public ProjectFormPage SetName()
        {
            var projectName = form.Name;
            if (string.IsNullOrEmpty(projectName))
            {
                throw new System.ArgumentException($"'{projectName}' cannot be null or empty", projectName);
            }

            var nameInput = pageElements.GetProjectNameInput();
            nameInput.SendKeys(projectName);

            return this;
        }

        public ProjectFormPage SetDescriptions()
        {
            var description = form.Description;
            if (!string.IsNullOrEmpty(description))
            {
                var descriptionsInput = pageElements.GetDescriptionNameInput();
                descriptionsInput.SendKeys(description);
            }

            return this;
        }

        public ProjectFormPage SetVisibility()
        {
            var radioButton = form.Visibility switch
            {
                Visibility.Public => pageElements.GetPublicVisibilityButton(),
                Visibility.Private => pageElements.GetPrivateVisibilityButton(),
                _ => throw new System.NotImplementedException()
            };
            radioButton.Click();

            return this;
        }

        public ProjectsPage Submit()
        {
            var submitButton = pageElements.GetSubmitButton();
            submitButton.Click();

            return new ProjectsPage();
        }
    }
}