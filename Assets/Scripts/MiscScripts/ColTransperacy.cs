using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColTransperacy : MonoBehaviour
{
    private static List<GameObject> items = new List<GameObject>();
    private void Start()
    {
        Transform parentTransform = gameObject.transform;

        foreach (Transform child in parentTransform)
        {
            items.Add(child.gameObject);
            SetInitialTransparency(child.gameObject);
            Debug.Log($"{child.name}");
        }
    }

    //Padaro png pilnai rysku kai paemi
    public static void PickUpCollectible(string tag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);

        if (taggedObjects.Length > 0)
        {
            foreach (GameObject obj in taggedObjects)
            {
                //Debug.Log("Collectible found");
                RawImage rawImage = obj.GetComponent<RawImage>();
                if (rawImage != null)
                {
                    Debug.Log($"RawImage found: {obj.name}");
                    Color currentColor = rawImage.color;
                    currentColor.a = 1f;
                    rawImage.color = currentColor;
                    return;
                }
                //else
                    //Debug.Log($"RawImage not found in {obj.name}");
            }

        }
        //else
            //Debug.Log($"No UI element found with tag: {tag}");

    }
    //Padaro png pusiau rysku
    private void SetInitialTransparency(GameObject obj)
    {
        if (obj != null)
        {
            RawImage rawImage = obj.GetComponent<RawImage>();
            if (rawImage != null)
            {
                Color currentColor = rawImage.color;
                currentColor.a = 0.3f;
                rawImage.color = currentColor;
            }
        }
    }
    //Ui item count get
    public int GetUiItemCount()
    {
        return items.Count;
    }
}
