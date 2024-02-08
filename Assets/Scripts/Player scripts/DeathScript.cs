using System;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    HealthController healthController;
    public JSScript jumpScareScript;
    void Start()
    {
        healthController = GetComponent<HealthController>();
        //playerMovementScript = GetComponent<PlayerMovement>();

        if (healthController!= null)
        {
            healthController.OnHealthZero += HandleOnHealthZero;

        }
        else
        {
            Debug.Log("HP scripto nerado");
        }
    }
    void HandleOnHealthZero()
    {
        if(healthController.sanity < 1)
        {
            jumpScareScript.JumpScareCall(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (healthController != null)
        {
            healthController.OnHealthZero -= HandleOnHealthZero;
        }
    }
}
