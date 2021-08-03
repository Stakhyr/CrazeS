using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagicBar : MonoBehaviour
{
    public Slider mSlider;
    public Image fill;

    public void SetMaxMagicAmount(int magic)
    {
        mSlider.maxValue = magic;
        mSlider.value = magic;
       
    }

    public void SetMagicAmount(int magic)
    {
        mSlider.value = magic;

    }
}
