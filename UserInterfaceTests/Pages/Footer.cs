using OpenQA.Selenium;
using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class Footer
    {
        private readonly FooterElements footerElements = new FooterElements();
        private IWebElement dropDawnCaretButton;

        public ProfileAreaMenu DropDownCaretClick()
        {
            if (!TryToSetDropDawnCaretElementAtCurrentPage())
            {
                throw new NoSuchElementException("Footer does not exists.");
            }

            dropDawnCaretButton.Click();

            return new ProfileAreaMenu();
        }

        private bool TryToSetDropDawnCaretElementAtCurrentPage()
        {
            try
            {
                dropDawnCaretButton = footerElements.FindDropDownCaret();
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }
    }
}
