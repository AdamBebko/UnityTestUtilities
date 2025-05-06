using JetBrains.Annotations;
using NUnit.Framework;

namespace EditorTestUtilities
{
    /// <summary>
    /// A class to make unit testing events easier.
    /// </summary>
    public class EventListener
    {
        int _firedCount;
        
        /// <summary>
        /// Asserts that the event was raised at least one time.
        /// </summary>
        [PublicAPI]
        public void WasRaised()
        {
            Assert.That(_firedCount > 0,
                "Expected event to fire, " +
                "but it did not.");
        }

        /// <summary>
        /// Asserts that the event never raised.
        /// </summary>
        [PublicAPI]
        public void WasNotRaised()
        {
            Assert.That(_firedCount == 0,
                "Expected event to NOT fire, " +
                "but it DID.");
        }

        /// <summary>
        /// Asserts that the event was raised exactly one time.
        /// </summary>
        [PublicAPI]
        public void WasRaisedOnce()
        {
            Assert.That(_firedCount == 1,
                $"Expected event to fire once, " +
                $"but it fired {_firedCount} times");
        }

        /// <summary>
        /// Asserts that the event was raised exactly x number of times.
        /// </summary>
        /// <param name="numberOfTimes">The number of times it should have been raised</param>
        [PublicAPI]
        public void WasRaisedThisManyTimes(int numberOfTimes)
        {
            Assert.That(_firedCount == 1,
                $"Expected event to fire {numberOfTimes}, " +
                $"but it fired {_firedCount} times");
        }

        /// <summary>
        /// Listens to an event with no parameters
        /// </summary>
        [PublicAPI]
        public void Listen()
        {
            _firedCount++;
        }
        
        /// <summary>
        /// Listens to an event with 1 parameters
        /// </summary>
        [PublicAPI]
        public void Listen<T>(T _)
        {
            _firedCount++;
        }
        
        /// <summary>
        /// Listens to an event with 2 parameters
        /// </summary>
        [PublicAPI]
        public void Listen<T, T2>(T _, T2 __)
        {
            _firedCount++;
        }
        
        /// <summary>
        /// Listens to an event with 3 parameters
        /// </summary>
        [PublicAPI]
        public void Listen<T, T2, T3>(T _, T2 __, T3 ___)
        {
            _firedCount++;
        }
        
        /// <summary>
        /// Listens to an event  with 4 parameters
        /// </summary>
        [PublicAPI]
        public void Listen<T, T2, T3, T4>(T _, T2 __, T3 ___, T4 ____)
        {
            _firedCount++;
        }

    }
    
}
