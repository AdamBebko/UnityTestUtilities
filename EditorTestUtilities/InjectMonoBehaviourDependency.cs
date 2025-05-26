using System.Reflection;
using UnityEngine;

namespace EditorTestUtilities
{
    public static class TestDependencyInjector
    {
        public static void Inject(this MonoBehaviour instance, string fieldName, object value)
        {
            var field = instance.GetType().GetField(fieldName, 
                BindingFlags.NonPublic | BindingFlags.Instance);
            
            if (field != null)
            {
                field.SetValue(instance, value);
            }
        }
    }
}