using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBar : MonoBehaviour {

    Slider slider;
    public static float damageBarValue;
    public int baseDamageValue;

    void Awake() {
        slider = GetComponent<Slider>();
        DamagePicker.damageAction += DamageTaken;
    }

    void DamageTaken(GameObject item) {
        int damageValue;
        damageValue = item.GetComponent<GoodParam>().SymbolIndex == 2 ? 5 * baseDamageValue : baseDamageValue;
        slider.value += damageValue;
    }

    void Update() {

    }
}
