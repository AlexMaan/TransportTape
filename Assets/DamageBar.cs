using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBar : MonoBehaviour {

    Slider slider;
    // public static float damageBarValue;
    public float damageTimeProgressK;
    public int baseDamageValue;
    ProgressWheel progressWheel;
    //public float timeProgressK;
    float pauseUnlocker;
    public int pauseUnlockTrigger;

    void Awake() {
        slider = GetComponent<Slider>();
        DamagePicker.damageAction += DamageTaken;
        progressWheel = FindObjectOfType<ProgressWheel>();
        if (PlayerPrefs.HasKey("setupDamage")) damageTimeProgressK = int.Parse(PlayerPrefs.GetString("setupDamage"));
    }

    void Update() {
        slider.value += Time.deltaTime * damageTimeProgressK; 
        if (slider.value >= slider.maxValue) { progressWheel.EndRoundTrigger(0); }
        //slider.value += timeProgressK * Time.deltaTime;
    }

    void DamageTaken(GameObject item) {
        float damageValue;
        damageValue = item.GetComponent<GoodParam>().SymbolIndex == 2 ? 5 * baseDamageValue : 0 * baseDamageValue;
        slider.value += damageValue;
        PauseUnlockCounter(damageValue);
    }

    void PauseUnlockCounter(float damageValue) {
        pauseUnlocker += damageValue;
        if (pauseUnlocker >= pauseUnlockTrigger) { pauseUnlocker = 0; TapeSpeedPause.pauseButtonCounter += 5; }
    }    
}
