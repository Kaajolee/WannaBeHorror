using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Transform playerCamera;
    private Light flashlight;
    void Update()
    {
        transform.position = playerCamera.position;
        transform.rotation = playerCamera.rotation;
        flashlight = GetComponent<Light>();
        OnOff();

    }
    private void OnOff()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
