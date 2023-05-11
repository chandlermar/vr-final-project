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
    [Header("RESET")]
    public Button resetButton;

    [Header("SPAWN")]
    public Button spawnButton;

    [Header("Interaction Distance")]
    public Slider interactionSlider;

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

    [Header("Red Attract Red Slider")]
    public Slider slider7;

    [Header("Green Attract Green Slider")]
    public Slider slider8;

    [Header("Blue Attract Blue Slider")]
    public Slider slider9;

    // Start is called before the first frame update
    void Start()
    {
        //Sets default slider configuration 
        //Max: 50 ,Min: -50 ,Default: 0
        //Negative = repulse
        //Positive = attract

        slider1.minValue = -25;
        slider1.maxValue = 25;
        slider1.value = 0;

        slider2.minValue = -25;
        slider2.maxValue = 25;
        slider2.value = 0;

        slider3.minValue = -25;
        slider3.maxValue = 25;
        slider3.value = 0;

        slider4.minValue = -25;
        slider4.maxValue = 25;
        slider4.value = 0;

        slider5.minValue = -25;
        slider5.maxValue = 25;
        slider5.value = 0;

        slider6.minValue = -25;
        slider6.maxValue = 25;
        slider6.value = 0;

        slider7.minValue = -25;
        slider7.maxValue = 25;
        slider7.value = 0;

        slider8.minValue = -25;
        slider8.maxValue = 25;
        slider8.value = 0;

        slider9.minValue = -25;
        slider9.maxValue = 25;
        slider9.value = 0;

        interactionSlider.minValue = 0;
        interactionSlider.maxValue = 15;
        interactionSlider.value = 5;
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
        slider7.wholeNumbers = true;
        slider8.wholeNumbers = true;
        slider9.wholeNumbers = true;
        interactionSlider.wholeNumbers = true;
    }

    public void resetParticles()
    {
        foreach (GameObject particle in ParticleInteraction.inst.particlesRed)
        {
            Destroy(particle);
        }

        foreach (GameObject particle in ParticleInteraction.inst.particlesBlue)
        {
            Destroy(particle);
        }

        foreach (GameObject particle in ParticleInteraction.inst.particlesGreen)
        {
            Destroy(particle);
        }

        resetSliderValues();
    }

    void resetSliderValues()
    {

        slider1.value = 0;
        slider2.value = 0;
        slider3.value = 0;
        slider4.value = 0;
        slider5.value = 0;
        slider6.value = 0;
        slider7.value = 0;
        slider8.value = 0;
        slider9.value = 0;
        interactionSlider.value = 5;

    }
}

    
