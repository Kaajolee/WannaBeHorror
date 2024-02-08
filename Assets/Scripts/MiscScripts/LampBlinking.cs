using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlinking : MonoBehaviour
{
    public float minBlinkTimerRange;
    public float maxBlinkTimerRange;
    Light testLight;
    void Start()
    {
        testLight = GetComponent<Light>();
        StartCoroutine(LightFlash());
    }
    IEnumerator LightFlash()
    {

        while(true)
            
        {
            //Debug.Log("enumerator entered");
            yield return new WaitForSeconds(Random.Range(minBlinkTimerRange, maxBlinkTimerRange));
            testLight.enabled = !testLight.enabled;
        }
    }
}
