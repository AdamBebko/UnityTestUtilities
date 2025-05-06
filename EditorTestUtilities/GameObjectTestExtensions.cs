using JetBrains.Annotations;
using UnityEngine;

namespace EditorTestUtilities
{
    public static class GameObjectTestExtensions
    {
        /// <summary>
        /// An action to be performed before awake is called, usually some kind of dependency injection
        /// </summary>
        /// <typeparam name="T">This is the component that is being injected. Useful parameter for lambda functions</typeparam>
        [PublicAPI]
        public delegate void InjectionAction<T>(T component) where T: Component;
        
        /// <summary>
        /// Since AddComponent() calls Awake() immediately, it doesn't allow for testing injected objects in Awake().
        /// This script delays Awake() such that you can inject behaviour beforehand.
        /// Use a lambda expression to tell the component what to do before Awake.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="injectAction">Pass a lambda function here for setting up the component before Awake.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [PublicAPI]
        public static T AddComponentWithInjectionBeforeAwake<T>(this GameObject gameObject, InjectionAction<T> injectAction) where T : Component
        {
            gameObject.SetActive(false);
            T component = gameObject.AddComponent<T>();
            injectAction.Invoke(component);
            gameObject.SetActive(true);
            return component;
        }

    }
}