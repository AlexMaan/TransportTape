using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerBar : MonoBehaviour {

    Slider slider;
    public static float powerBarValue;   
    public float powerDownK;


    void Awake() {
        slider = GetComponent<Slider>();
        powerBarValue = slider.maxValue / 2;
    }

    void Update () {
        powerBarValue -= powerDownK * Time.deltaTime;
        slider.value = powerBarValue;
        if (powerBarValue <= slider.minValue) SceneManager.LoadScene("End");
        //if (powerBarValue >= slider.maxValue) SceneManager.LoadScene("End");
    }
}
