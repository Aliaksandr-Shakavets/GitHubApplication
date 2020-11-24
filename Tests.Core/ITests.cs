using System;

namespace UserInterfaceTests
{
    public interface ITests : IDisposable
    {
        /// <summary>
        /// Method executed once before calling all tests.
        /// </summary>
        void RunBeforeAnyTests();

        /// <summary>
        /// Method executs after calling all tests.
        /// </summary>
        void RunAfterAnyTests();

        /// <summary>
        /// Method executed once before calling each tests.
        /// </summary>
        void RunBeforeEachTest();

        /// <summary>
        /// Method executs after calling each tests.
        /// </summary>
        void RunAfterEachTest();
    }
}
