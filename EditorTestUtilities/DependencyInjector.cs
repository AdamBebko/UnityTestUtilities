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
                if (!field.FieldType.IsAssignableFrom(value.GetType()))
                {
                    throw new ArgumentException($"Injector failed: Field {fieldName} is of type {field.FieldType} but value is of type {value.GetType()} and does not inherit from it.");   
                }
                field.SetValue(instance, value);
            }
            else
            {
                throw new ArgumentException($"Injector failed: Field {fieldName} not found on object of type {monoBehaviourType}");  
            }
        }
    }
}