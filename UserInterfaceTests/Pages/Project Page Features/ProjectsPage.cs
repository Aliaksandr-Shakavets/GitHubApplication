using System.Linq;
using Tests.Core.Data_access_layer;
using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class ProjectsPage : Footer
    {
        private readonly ProjectsPageElements pageElements = new ProjectsPageElements();

        public ProjectFormPage CreateNewProject(ProjectFormInfo projectForm)
        {
            if (projectForm is null)
            {
                throw new System.ArgumentNullException(nameof(projectForm));
            }

            var newProjectButton = pageElements.GetNewProjectButtom();
            newProjectButton.Click();

            return new ProjectFormPage(projectForm);
        }

        public bool ContainsOpenProject(string projectName)
        {
            var existsOpenProjects = pageElements.GetProjects();

            return existsOpenProjects.Any(p => p.Text == projectName);
        }

        public bool ContainsClosedProject(string projectName)
        {
            pageElements.GetClosedProjectsButton().Click();
            var existsClosedProjects = pageElements.GetProjects();

            return existsClosedProjects.Any(p => p.Text == projectName);
        }

        internal ProjectsPage CloseProject(string projectName)
        {
            if (!ContainsOpenProject(projectName))
            {
                throw new System.ArgumentException($"{projectName} does not exists at open projects.", nameof(projectName));
            }

            var menu = pageElements.GetProjectMenu(projectName);
            menu.Click();
            pageElements.GetCloseButton().Click();

            return this;
        }
    }
}