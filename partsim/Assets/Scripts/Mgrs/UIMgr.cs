using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    public static UIMgr inst;

    private void Awake()
    {
        inst = this;
    }

    /*---------- Properties ----------*/
    [Header("Red Attract Blue Slider")]
    public Slider slider1;

    [Header("Red Attract Green Slider")]
    public Slider slider2;

    [Header("Blue Attract Green Slider")]
    public Slider slider3;

    [Header("Blue Attract Red Slider")]
    public Slider slider4;

    [Header("Green Attract Red Slider")]
    public Slider slider5;

    [Header("Green Attract Blue Slider")]
    public Slider slider6;

    // Start is called before the first frame update
    void Start()
    {
        //Sets default slider configuration 
        //Max: 50 ,Min: -50 ,Default: 0
        //Negative = repulse
        //Positive = attract

        slider1.minValue = -50;
        slider1.maxValue = 50;
        slider1.value = 0;

        slider2.minValue = -50;
        slider2.maxValue = 50;
        slider2.value = 0;

        slider3.minValue = -50;
        slider3.maxValue = 50;
        slider3.value = 0;

        slider4.minValue = -50;
        slider4.maxValue = 50;
        slider4.value = 0;

        slider5.minValue = -50;
        slider5.maxValue = 50;
        slider5.value = 0;

        slider6.minValue = -50;
        slider6.maxValue = 50;
        slider6.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Forces sliders to snap to whole values
        slider1.wholeNumbers = true;
        slider2.wholeNumbers = true;
        slider3.wholeNumbers = true;
        slider4.wholeNumbers = true;
        slider5.wholeNumbers = true;
        slider6.wholeNumbers = true;
    }
}
