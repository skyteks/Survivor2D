using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField]
    private Image slider;

    public void ChangeHealthSlider(float percentage)
    {
        slider.fillAmount = Mathf.Clamp01(percentage);
    }
}
