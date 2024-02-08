using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HP_STAMUIscript : MonoBehaviour
{
    public StaminaController controller;
    public HealthController healthController;

    private enum UIType
    {
        //hp,
        HpBar,
        //stamina,
        staminaBar,
        Other

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessUiElements();


    }
    private void ProcessUiElements()
    {
        foreach (Transform t in transform)
        {
            if (t.CompareTag("StatPanel"))
            {
                ProcessUiChildren(t);
            }
        }
    }
    private void ProcessUiChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            UIType uiType = GetUIType(child.tag);
            switch (uiType)
            {
                case UIType.HpBar:
                    Slider hpBar = child.GetComponent<Slider>();
                    hpBar.value = healthController.sanity;
                    break;
                case UIType.staminaBar:
                    Slider staminaBar = child.GetComponent<Slider>();
                    staminaBar.value = controller.currentStamina;
                    break;

            }
        }
    }
    private UIType GetUIType(string tag)
    {
        switch (tag)
        {
            case "hpBar":
                return UIType.HpBar;
            case "staminaBar":
                return UIType.staminaBar;
            default:
                return UIType.Other;
        }
    }
}
