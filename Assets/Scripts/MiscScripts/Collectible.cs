using System;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    public static UnityEvent OnCollectiblePickedUp =>
        CollectibleEventSystem.OnCollectiblePickedUp;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollectiblePickedUp.Invoke();
            ColTransperacy.PickUpCollectible(gameObject.tag);
            Destroy(gameObject);    
        }
    }
}
