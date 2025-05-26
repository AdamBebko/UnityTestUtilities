using UnityEngine;

namespace TestScripts
{
    public class MonobehaviourWithPrivatePropertyToInject : MonoBehaviour
    {
        GameObject _injected;
        ISomeInterface _injectedInterface;

        public GameObject ReadInjectedDependency => _injected;
        public ISomeInterface ReadInjectedInterface => _injectedInterface;
    }
}