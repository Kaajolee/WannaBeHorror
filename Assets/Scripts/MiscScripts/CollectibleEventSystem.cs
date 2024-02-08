using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CollectibleEventSystem : MonoBehaviour
{
    int count = 0;
    //public TMP_Text text;
    public static UnityEvent OnCollectiblePickedUp = new UnityEvent();
    public ColTransperacy colTrans;
    private void Start()
    {
        //UpdateCollectibleCountText();
    }
    private void Update()
    {

    }
    private void OnEnable()
    {
        OnCollectiblePickedUp.AddListener(IncrementCollectibleCount);
    }
    private void OnDisable()
    {
        OnCollectiblePickedUp.RemoveListener(IncrementCollectibleCount);
    }
    private void IncrementCollectibleCount()
    {
        count++;
        if (count == 2)
            Debug.Log("Visi col surinkti");
    }
}
