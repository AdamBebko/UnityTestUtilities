using System;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EditorTestUtilities
{
    [PublicAPI]
    public static class TearDownGameObjects
    {
        /// <summary>
        /// To be called in the TearDown method of unit tests. Effectively clears the scene of all gameObjects.
        /// </summary>
        public static void All()
        {
            var objects = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None).ToList();
            foreach (GameObject gameObject in objects)
            {
                try
                {
                    Object.DestroyImmediate(gameObject);
                }
                catch (InvalidOperationException)
                {
                    //do nothing
                }
            }
        }
    }
}
