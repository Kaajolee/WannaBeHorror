using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public static UnityEvent OnCollectiblePickedUp => CollectibleEventSystem.OnCollectiblePickedUp;

    public KeyCode pickUpKey = KeyCode.E;
    public TMP_Text itemTag;
    public float pickUpRange;
    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        //sauna spinduli i objekta
        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            //Debug.Log("Raycast length and tag: " + $"{hit.distance} , {hit.collider.gameObject.tag}");
            //tikrina ar spaudziamas e ir patikrina objekto taga
            if (Input.GetKey(pickUpKey) && hit.collider.tag.Contains("Collectible")) 
            { 
                //if (hit.collider.tag.Contains("Collectible"))
                //{
                    OnCollectiblePickedUp.Invoke(); // individualaus collectible eventas(+1 prie total)
                    ColTransperacy.PickUpCollectible(hit.collider.tag); //ui update
                    //itemTag.text = hit.collider.tag; // virsuje po kaire texto updeitas
                    Destroy(hit.collider.gameObject); // sunaikina collectible
                //}
            }
        }
    }
}
