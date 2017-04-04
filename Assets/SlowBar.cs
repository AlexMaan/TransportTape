using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowBar : MonoBehaviour {

    public Slider slider;
        
    public float SlowBarValue {

        get { return slider.value; }
        set { slider.value = value; }
    }

    void Awake(){
        slider.value = slider.minValue;
    }
}
