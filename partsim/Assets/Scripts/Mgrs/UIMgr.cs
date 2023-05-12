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

    //0=not spawned, 1 = spawned
    public int hasSpawnedFlag = 0;

    /*---------- Properties ----------*/
    [Header("RESET")]
    public Button resetButton;

    [Header("SPAWN")]
    public Button spawnButton;

    [Header("Interaction Distance")]
    public Slider interactionSlider;

    [Header("Red Attract Blue Slider")]
    public Slider redBlue;

    [Header("Red Attract Green Slider")]
    public Slider redGreen;

    [Header("Blue Attract Green Slider")]
    public Slider blueGreen;

    [Header("Blue Attract Red Slider")]
    public Slider blueRed;

    [Header("Green Attract Red Slider")]
    public Slider greenRed;

    [Header("Green Attract Blue Slider")]
    public Slider greenBlue;

    [Header("Red Attract Red Slider")]
    public Slider redRed;

    [Header("Green Attract Green Slider")]
    public Slider greenGreen;

    [Header("Blue Attract Blue Slider")]
    public Slider blueBlue;

    // Start is called before the first frame update
    void Start()
    {
        //Sets default slider configuration 
        //Max: 50 ,Min: -50 ,Default: 0
        //Negative = repulse
        //Positive = attract

        redBlue.minValue = -25;
        redBlue.maxValue = 25;
        redBlue.value = 0;

        redGreen.minValue = -25;
        redGreen.maxValue = 25;
        redGreen.value = 0;

        blueGreen.minValue = -25;
        blueGreen.maxValue = 25;
        blueGreen.value = 0;

        blueRed.minValue = -25;
        blueRed.maxValue = 25;
        blueRed.value = 0;

        greenRed.minValue = -25;
        greenRed.maxValue = 25;
        greenRed.value = 0;

        greenBlue.minValue = -25;
        greenBlue.maxValue = 25;
        greenBlue.value = 0;

        redRed.minValue = -25;
        redRed.maxValue = 25;
        redRed.value = 0;

        greenGreen.minValue = -25;
        greenGreen.maxValue = 25;
        greenGreen.value = 0;

        blueBlue.minValue = -25;
        blueBlue.maxValue = 25;
        blueBlue.value = 0;

        interactionSlider.minValue = 0;
        interactionSlider.maxValue = 15;
        interactionSlider.value = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //Forces sliders to snap to whole values
        redBlue.wholeNumbers = true;
        redGreen.wholeNumbers = true;
        blueGreen.wholeNumbers = true;
        blueRed.wholeNumbers = true;
        greenRed.wholeNumbers = true;
        greenBlue.wholeNumbers = true;
        redRed.wholeNumbers = true;
        greenGreen.wholeNumbers = true;
        blueBlue.wholeNumbers = true;
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
        hasSpawnedFlag = 0; //particles are despawned.
    }

    void resetSliderValues()
    {

        redBlue.value = 0;
        redGreen.value = 0;
        blueGreen.value = 0;
        blueRed.value = 0;
        greenRed.value = 0;
        greenBlue.value = 0;
        redRed.value = 0;
        greenGreen.value = 0;
        blueBlue.value = 0;
        interactionSlider.value = 5;

    }
}

    
