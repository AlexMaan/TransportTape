using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressWheel : MonoBehaviour {

    public Slider slider;
    public static float levelProgress;
    public float viewProgress;

    public delegate void EndRound(int roundResult);
    public static event EndRound roundIsEnded;

    public void EndRoundTrigger(int roundResult) {
        roundIsEnded(roundResult);
    }

    void Update() {
        if (levelProgress >= slider.maxValue) { levelProgress = slider.maxValue; roundIsEnded(1); }
        slider.value = levelProgress;
        viewProgress = levelProgress;
    }
}
