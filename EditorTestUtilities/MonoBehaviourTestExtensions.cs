using System;
using System.Reflection;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

namespace EditorTestUtilities
{
    public static class MonoBehaviourTestExtensions
    {
        /// <summary>
        /// Calls the Awake method via reflection for testing purposes
        /// </summary>
        /// <param name="monoBehaviour"></param>
        public static void CallAwake(this MonoBehaviour monoBehaviour)
        {
            RunVoidUnityMethod(monoBehaviour, "Awake");
        }
        
        
        /// <summary>
        /// Calls the Update method via reflection for testing purposes
        /// </summary>
        /// <param name="monoBehaviour"></param>
        public static void CallUpdate(this MonoBehaviour monoBehaviour)
        {
            RunVoidUnityMethod(monoBehaviour, "Update");
        }
        
        
        /// <summary>
        /// Calls the LateUpdate method via reflection for testing purposes
        /// </summary>
        /// <param name="monoBehaviour"></param>
        public static void CallLateUpdate(this MonoBehaviour monoBehaviour)
        {
            RunVoidUnityMethod(monoBehaviour, "LateUpdate");
        }
        
        /// <summary>
        /// Calls the FixedUpdate method via reflection for testing purposes
        /// </summary>
        /// <param name="monoBehaviour"></param>
        public static void CallFixedUpdate(this MonoBehaviour monoBehaviour)
        {
            RunVoidUnityMethod(monoBehaviour, "FixedUpdate");
        }

        /// <summary>
        /// Calls the Start method via reflection for testing purposes
        /// </summary>
        /// <param name="monoBehaviour"></param>
        public static void CallStart(this MonoBehaviour monoBehaviour)
        {
            RunVoidUnityMethod(monoBehaviour, "Start");
        }

        /// <summary>
        /// Calls the OnEnable method via reflection for testing purposes
        /// </summary>
        /// <param name="monoBehaviour"></param>
        [PublicAPI]
        public static void CallOnEnable(this MonoBehaviour monoBehaviour)
        {
            RunVoidUnityMethod(monoBehaviour, "OnEnable");
        }
        
        /// <summary>
        /// Calls the OnDisable method via reflection for testing purposes
        /// </summary>
        /// <param name="monoBehaviour"></param>
        [PublicAPI]
        public static void CallOnDisable(this MonoBehaviour monoBehaviour)
        {
            RunVoidUnityMethod(monoBehaviour, "OnDisable");
        }

        /// <summary>
        /// Calls the OnTriggerEnter2D method via reflection for testing purposes
        /// </summary>
        /// <param name="monoBehaviour"></param>
        /// <param name="other"></param>
        public static void CallOnTriggerEnter2D(this MonoBehaviour monoBehaviour, Collider2D other)
        {
            RunUnityCollider2DMethod(monoBehaviour, other, "OnTriggerEnter2D");
        }

        /// <summary>
        /// Calls the OnTriggerExit2D method via reflection for testing purposes
        /// </summary>
        /// <param name="monoBehaviour"></param>
        /// <param name="other"></param>
        public static void CallOnTriggerExit2D(this MonoBehaviour monoBehaviour, Collider2D other)
        {
            RunUnityCollider2DMethod(monoBehaviour, other, "OnTriggerExit2D");
        }
        
        static void RunVoidUnityMethod(MonoBehaviour monoBehaviour, string methodName)
        {
            Type type = monoBehaviour.GetType();
            CallMethodOnType(monoBehaviour, methodName, type);
        }

        static void CallMethodOnType(MonoBehaviour monoBehaviour, string methodName, Type type)
        {
            if (monoBehaviour == null) throw new NullReferenceException("Passed monoBehaviour is null");
            MethodInfo voidMethod = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (voidMethod != null)
            {
                voidMethod.Invoke(monoBehaviour, null);
            }
            else
            {
                Type baseType = type.BaseType;
                if (baseType == typeof(MonoBehaviour))
                    Assert.Fail($"{methodName} method not found via reflection in type: {type}");
                else
                {
                    CallMethodOnType(monoBehaviour, methodName, baseType);
                }
            }
        }

        static void RunUnityCollider2DMethod(MonoBehaviour monoBehaviour, Collider2D other, string methodName)
        {
            Type type = monoBehaviour.GetType();
            MethodInfo awakeMethod = type.GetMethod(methodName,BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Collider2D) }, null);
            if (awakeMethod != null)
            {
                awakeMethod.Invoke(monoBehaviour, new object[] {other});
            }
            else
            {
                Assert.Fail($"{methodName} method not found via reflection in type: {type}");
            }
        }
    }
}