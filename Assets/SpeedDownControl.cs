using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownControl : MonoBehaviour {

    SpeedUpControl speedUpC;
    SlowBar slowBar;
    public float slowBarDownK;

    void Start() {
        speedUpC = FindObjectOfType<SpeedUpControl>();
        slowBar = FindObjectOfType<SlowBar>();
    }
    
    public void SpeedDownButton() {
        speedUpC.slider.value = speedUpC.slider.minValue;        
        StartCoroutine("DownTapeSpeed");
    }

    IEnumerator DownTapeSpeed() {
        yield return new WaitForEndOfFrame();
        speedUpC.slowMode = true;
        Time.timeScale = 0.5f;

        while (slowBar.SlowBarValue >1f) {
            slowBar.SlowBarValue -= slowBarDownK * Time.deltaTime;
            yield return null;
        }
        Time.timeScale = 1;        
    }

    public void BreakSlowMode(){
        StopCoroutine("DownTapeSpeed");
        Time.timeScale = 1;
    }
}
