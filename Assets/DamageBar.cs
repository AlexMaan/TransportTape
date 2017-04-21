using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBar : MonoBehaviour {

    Slider slider;
   // public static float damageBarValue;
    public int baseDamageValue;
    ProgressWheel progressWheel;
    public float timeProgressK;

    void Awake() {
        slider = GetComponent<Slider>();
        DamagePicker.damageAction += DamageTaken;
        progressWheel = FindObjectOfType<ProgressWheel>();
    }

    void DamageTaken(GameObject item) {
        float damageValue;
        damageValue = item.GetComponent<GoodParam>().SymbolIndex == 2 ? 5 * baseDamageValue : 0.2f * baseDamageValue;
        slider.value += damageValue;
    }

    void Update() {
        if (slider.value >= slider.maxValue) { progressWheel.EndRoundTrigger(0); }
        //slider.value += timeProgressK * Time.deltaTime;
    }
}
