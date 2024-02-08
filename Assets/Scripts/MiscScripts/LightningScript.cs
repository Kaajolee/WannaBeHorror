using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    private Light light;
    private AudioSource audio;
    public int minWaitForLightning;
    public int maxWaitForLightning;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        audio = GetComponent<AudioSource>();
        light.enabled = false;
        StartCoroutine(LightningStrike(light));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LightningStrike(Light light)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitForLightning, maxWaitForLightning));
            audio.Play();
            light.enabled = !light.enabled;
            //audio.Play();
            yield return new WaitForSeconds(Random.Range(0.01f, 0.03f));
            light.enabled = !light.enabled;
            yield return new WaitForSeconds(Random.Range(0.04f, 0.08f));
            light.enabled = !light.enabled;
            yield return new WaitForSeconds(Random.Range(0.02f, 0.06f));
            light.enabled = !light.enabled;
        }
    }
}
