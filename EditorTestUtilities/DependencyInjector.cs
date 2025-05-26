using System;
using System.Reflection;
using UnityEngine;

namespace EditorTestUtilities
{
    /// <summary>
    /// Tools to help inject dependencies into monobehaviours for testing purposes.
    /// </summary>
    public static class DependencyInjector
    {
        /// <summary>
        /// Injects a dependency into a private field. Will raise exceptions if
        /// the inputted type does not match the field type
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        public static void Inject(this MonoBehaviour instance, string fieldName, object value)
        {
            Type monoBehaviourType = instance.GetType();
            var field = monoBehaviourType.GetField(fieldName, 
                BindingFlags.NonPublic | BindingFlags.Instance);
            
            if (field != null)
            {
                // Ensure the value can be assigned to the field's type
                if (field.FieldType.IsInstanceOfType(value))
                {
                    field.SetValue(instance, value);
                }
                else
                {
                    // This error message will be more descriptive if the type mismatch occurs
                    throw new ArgumentException($"Injector failed: Value of type '{value.GetType()}' cannot be converted to field type '{field.FieldType}' for field '{fieldName}' on object of type '{monoBehaviourType}'");
                }

            }
            else
            {
                throw new ArgumentException($"Injector failed: Field {fieldName} not found on object of type {monoBehaviourType}");  
            }
        }
    }
}