using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpControl : MonoBehaviour {

    public Slider slider;
    float sliderValue;
    float startSpeed;
    SlowBar slowBar;
    public float slowBarUpK;
    SpeedDownControl speedDownControl;
    public bool slowMode = false;

   void Start() {
        speedDownControl = FindObjectOfType<SpeedDownControl>();
        slowBar = FindObjectOfType<SlowBar>();
        slider = GetComponent<Slider>();
        sliderValue = slider.minValue;
        slider.value = sliderValue;
        startSpeed = TapeManager.tapeSpeed;
    }

    void Update () {
		if (slider.value != sliderValue) {
            if (slowMode) { speedDownControl.BreakSlowMode(); slowMode = false; }            
            TapeManager.tapeSpeed = startSpeed * slider.value;
            sliderValue = slider.value;
            
        }
        if (slider.value != slider.minValue) {
            slowBar.SlowBarValue += (slider.value - slider.minValue) / slider.minValue * slowBarUpK * Time.deltaTime;
        }
	}
}
