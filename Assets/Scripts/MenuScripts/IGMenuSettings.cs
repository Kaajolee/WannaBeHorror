using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMenuSettings : MonoBehaviour
{
    public Canvas settingsCanvas;
    public Canvas menuCanvas;
    private void Start()
    {
        settingsCanvas.enabled = false;
    }

    public void Transition()
    {
        menuCanvas.enabled = !menuCanvas.enabled;
        settingsCanvas.enabled = !settingsCanvas.enabled;
    }
}
