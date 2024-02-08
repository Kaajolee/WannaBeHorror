using UnityEngine;
using UnityEngine.Events;

public class ColEvents : MonoBehaviour
{
    public class ValueEvent : UnityEvent<string> { }
    public class Caller : MonoBehaviour
    {
        public ValueEvent valueEvent;
    }
    private Caller caller;

    private void OnEnable()
    {
        if (caller != null)
            caller.valueEvent.AddListener(ColTransperacy.PickUpCollectible);
    }
    private void OnDisable()
    {
        if (caller != null)
        caller.valueEvent.RemoveListener(ColTransperacy.PickUpCollectible);
    }

}
