using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class ProjectsPage : Footer
    {
        private readonly ProjectsPageElements pageElements = new ProjectsPageElements();

        public ProjectFormPage GoToNewProjectForm()
        {
            var newProjectButton = pageElements.GetNewProjectButtom();
            newProjectButton.Click();

            return new ProjectFormPage();
        }
    }
}