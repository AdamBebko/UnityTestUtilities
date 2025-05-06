using NUnit.Framework;
using UnityEngine;

namespace EditorTestUtilities
{
    /// <summary>
    /// A class to help unit testing vectors that accounts for floating point rounding errors
    /// </summary>
    public static class AssertVectors
    {
        const float DefaultTolerance = 0.0001f;
        
        /// <summary>
        /// Asserts that two vectors are equal, within a specified tolerance
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="tolerance"></param>
        public static void WithinTolerance(Vector3 expected, Vector3 actual, float tolerance = DefaultTolerance)
        {
            if (Vector3.Distance(expected, actual) > tolerance)
            {
                Assert.Fail($"\tExpected: {expected}\n" +
                            $"\tBut was: {actual}\n" +
                            $"\tTolerance: {tolerance}");
            }
        }
        
        /// <summary>
        /// Asserts that two vectors are not equal, given a specified tolerance
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="tolerance"></param>
        public static void NotWithinTolerance(Vector3 expected, Vector3 actual, float tolerance = DefaultTolerance)
        {
            if (Vector3.Distance(expected, actual) <= tolerance)
            {
                Assert.Fail($"\tExpected: {expected}\n" +
                            $"\tBut was: {actual}\n" +
                            $"\tTolerance: {tolerance}");
            }
        }
        
        /// <summary>
        /// Asserts that two vectors are equal, within a specified tolerance
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="tolerance"></param>
        public static void WithinTolerance(Vector2 expected, Vector2 actual, float tolerance = DefaultTolerance)
        {
            if (Vector2.Distance(expected, actual) > tolerance)
            {
                Assert.Fail($"\tExpected: {expected}\n" +
                            $"\tBut was: {actual}\n" +
                            $"\tTolerance: {tolerance}");
            }
        }
        
        /// <summary>
        /// Asserts that two vectors are not equal, given a specified tolerance
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="tolerance"></param>
        public static void NotWithinTolerance(Vector2 expected, Vector2 actual, float tolerance = DefaultTolerance)
        {
            if (Vector2.Distance(expected, actual) <= tolerance)
            {
                Assert.Fail($"\tExpected: {expected}\n" +
                            $"\tBut was: {actual}\n" +
                            $"\tTolerance: {tolerance}");
            }
        }
    }
}
