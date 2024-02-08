using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float maxSanity = 100f;
    public float sanity = 0f;

    public float sanityDamage = 1f;
    public float damageRadius = 10f;
    public float damageCoefficient = 0.02f;

    public float rechargeCooldown = 3f;
    public float healthIncrement = 2f;
    public float healthRegenCoefficient = 1.5f;
    public bool isDeathEventTriggered;

    public Transform enemyTransform;
    public event Action OnHealthZero;


    //public TextMeshPro textStamina;
    // Start is called before the first frame update
    void Start()
    {
        sanity = maxSanity;
        isDeathEventTriggered = false;

        StartCoroutine(HealthRegenerate(enemyTransform.position));
    }

    // Update is called once per frame
    void Update()
    {
        Damage(enemyTransform.position);
        Death();

    }
    private void Damage(Vector3 enemyPosition)
    {
        float distance = Vector3.Distance(transform.position, enemyPosition);
        if (distance != 0 && distance < damageRadius)
        {
            float adjustedDistance = Mathf.Max(damageRadius - distance, 0);
            sanity -= adjustedDistance * Time.deltaTime * damageCoefficient;
            sanity = Mathf.Clamp(sanity, 0f, 100f);
        }

    }
    //Health
    IEnumerator HealthRegenerate(Vector3 enemyPosition)
    {
        float distance = Vector3.Distance(transform.position, enemyPosition);
        while (true)
        {
            if (distance > damageRadius)
            {
                if (sanity <= maxSanity)
                {
                    sanity += healthIncrement * Time.deltaTime * healthRegenCoefficient;
                    yield return new WaitForSeconds(rechargeCooldown);

                }

            }
            else
            {
                StopCoroutine(HealthRegenerate(enemyPosition));
            }
            yield return null;


        }

    }
    private void Death()
    {
        if (sanity < 1 && !isDeathEventTriggered)
        {
            if (OnHealthZero != null)
            {
                OnHealthZero.Invoke();
            }
            isDeathEventTriggered = true;

        }
    }
}
