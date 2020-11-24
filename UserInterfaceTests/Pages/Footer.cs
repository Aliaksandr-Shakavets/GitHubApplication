using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class Footer
    {
        private readonly FooterElements footerElements = new FooterElements();

        public ProfileAreaMenu DropDownCaretClick()
        {
            footerElements.GetDropDownCaret().Click();

            return new ProfileAreaMenu();
        }
    }
}
