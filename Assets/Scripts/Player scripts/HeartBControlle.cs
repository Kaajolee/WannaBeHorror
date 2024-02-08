using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public HealthController healthC;
    private ParticleSystem particleSystemm;
    private ParticleSystem particleColor;
    // Start is called before the first frame update
    void Start()
    {
        particleSystemm = GetComponent<ParticleSystem>();
        particleColor = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        BeatChanger();
    }
    private void BeatChanger()
    {
        float currentHP = healthC.sanity;

        var mainModule = particleColor.main;
        var particleVelocity = particleSystemm.velocityOverLifetime;

        if (currentHP <= 100 && currentHP > 70)
        {
            particleVelocity.yMultiplier = 1f;
            mainModule.startColor = Color.green;
        }
        else if (currentHP < 70 && currentHP > 40)
        {
            particleVelocity.yMultiplier = 20f;
            mainModule.startColor = Color.yellow;

        }
        else if (currentHP < 40 && currentHP > 0)
        {
            particleVelocity.yMultiplier = 40f;
            mainModule.startColor = Color.red;

        }
    }
}
