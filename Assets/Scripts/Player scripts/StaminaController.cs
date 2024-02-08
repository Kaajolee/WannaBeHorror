using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{

    public float maxStamina = 100f;
    public float currentStamina = 0;
    public float staminaCooldown = 2f;
    public float staminaIncrease;
    private float cooldownTimer = 1.5f;
    private PlayerMovement mvPlayer;


    // Start is called before the first frame update
    void Start()
    {
        //textStamina.text = "0";
        currentStamina = maxStamina;
        mvPlayer = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator StaminaRecharge()
    {
        if (!mvPlayer.isSprinting)
        {
            yield return new WaitForSeconds(cooldownTimer);
            currentStamina += staminaIncrease * Time.deltaTime;
        }

    }
}
