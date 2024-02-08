using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class SettingsInGame : MonoBehaviour
{
    public void SettingsApplied()
    {
        Slider volumeSlider = null;
        Dropdown resolutionDropdown = null;
        Dropdown screenTypeDropdown = null;
        Debug.Log("Kodas veikia");
        Debug.Log(transform.childCount); 
        foreach (Transform child in transform)
        {
            //Debug.Log(child.name);
            foreach (Transform childchild in child)
            {
                //Debug.Log(childchild.name);
                
                if (childchild.gameObject.CompareTag("VolumeSlider"))
                {
                    volumeSlider = childchild.GetComponent<Slider>();
                }

                else if (childchild.gameObject.CompareTag("Resolution"))
                {
                    resolutionDropdown = childchild.GetComponent<Dropdown>();
                }
                else if (childchild.gameObject.CompareTag("ScreenType"))
                {
                    screenTypeDropdown = childchild.GetComponent<Dropdown>();
                }
            }
        }

        float volume = volumeSlider != null ? volumeSlider.value : 1f;
        int indexRes = resolutionDropdown != null ? resolutionDropdown.value : 0;
        int indexScr = screenTypeDropdown != null ? screenTypeDropdown.value : 0;


        AudioListener.volume = volume;

        if(indexRes == 0)
        {
            Screen.fullScreen = true; //Fullscreen
            Console.WriteLine("Fullscreen Applied");
        }
            

        else if (indexRes == 1)
            Screen.fullScreenMode = FullScreenMode.Windowed; //Windowed

        //-------------------

        if(indexScr == 0)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreenMode); //1920x1080
            Console.WriteLine("Resolution 1920x1080");
        }
            

        else if (indexScr == 1)
            Screen.SetResolution(1600, 800, Screen.fullScreenMode); //1600x800

        else if (indexScr == 2)
            Screen.SetResolution(1366, 766, Screen.fullScreenMode);//1366x766


    }
}
