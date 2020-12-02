using Tests.Core.Data_access_layer;
using UserInterfaceTests.Pages;

namespace UserInterfaceTests.Logic_steps
{
    internal static class ProjectsSteps
    {
        internal static ProjectsPage CreateNewProject(ProjectFormInfo projectForm)
        {
            return GoToProjectsPage()
                .CreateNewProject(projectForm)
                .SetName()
                .SetDescriptions()
                .SetVisibility()
                .Submit();
        }

        internal static bool ContainsOpenProject(string projectName) => GoToProjectsPage(false).ContainsOpenProject(projectName);

        internal static ProjectsPage GoToProjectsPage(bool needToSignIn = true)
        {
            if (needToSignIn)
            {
                return AuthenticationSteps.SignIn()
                                .DropDownCaretClick()
                                .GoToProjectPage();
            }

            return new Footer().DropDownCaretClick().GoToProjectPage();
        }

        internal static ProjectsPage CloseProject(string projectName)
        {
            return GoToProjectsPage(false).CloseProject(projectName);
        }

        internal static bool ContainsClosedProject(string projectName) => GoToProjectsPage(false).ContainsClosedProject(projectName);
    }
}
