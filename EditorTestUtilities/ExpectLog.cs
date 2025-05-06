using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TestTools;

namespace EditorTestUtilities
{
    public static class ExpectLog
    {
        public static void AnyError()
        {
            LogAssert.Expect(LogType.Error, new Regex(".*"));
        }
    }
}