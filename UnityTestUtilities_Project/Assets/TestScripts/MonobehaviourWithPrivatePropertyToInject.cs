using UnityEngine;

public class MonobehaviourWithPrivatePropertyToInject : MonoBehaviour
{
    GameObject _injected;

    public GameObject ReadInjectedDependency => _injected;
}
