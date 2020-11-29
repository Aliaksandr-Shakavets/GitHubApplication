using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class ProjectFormPage : Footer
    {
        private readonly ProjectFormPageElements pageElements = new ProjectFormPageElements();

        public ProjectFormPage SetNameInput(string projectName)
        {
            if (string.IsNullOrEmpty(projectName))
            {
                throw new System.ArgumentException($"'{nameof(projectName)}' cannot be null or empty", nameof(projectName));
            }

            var nameInput = pageElements.GetProjectNameInput();
            nameInput.SendKeys(projectName);

            return this;
        }

        public ProjectFormPage SetDescriptions(string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                var descriptionsInput = pageElements.GetDescriptionNameInput();
                descriptionsInput.SendKeys(description);
            }

            return this;
        }

        public ProjectFormPage SetPublicVisibility()
        {
            var radioButton = pageElements.GetPublicProjectRadioButton();
            radioButton.Click();

            return this;
        }

        public void SubmitProject()
        {
            var submitButton = pageElements.GetSubmitButton();
            submitButton.Click();
        }
    }
}