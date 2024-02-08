using System;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public AudioSource footstepSound, sprintSound;
    private PlayerMovement mvScript;
    public FogMode FogMode;
    private void Start()
    {
        mvScript = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        bool pressingKeys = Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Vertical") == 1;


        footstepSound.enabled = pressingKeys && !mvScript.isSprinting;
        if (mvScript.isSprinting)
        {
            sprintSound.enabled = true;
        }
        else
            sprintSound.enabled = false;

    }
}
