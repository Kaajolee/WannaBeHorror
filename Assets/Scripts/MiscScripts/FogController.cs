using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    public Color Color = Color.black;
    public float fogDensity = 0.1f;
    public float lightningScale = 0.1f;
    void Start()
    {
        RenderSettings.ambientIntensity = lightningScale;
        RenderSettings.fog = true;
        RenderSettings.fogDensity = fogDensity;
        RenderSettings.fogColor = Color;
    }
}
