using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePicker : MonoBehaviour {

    public GoodParam goodParam;
    public int symbolIndex;

    public delegate void DamagePick(GameObject item);
    public static event DamagePick damageAction;

    void Awake() {
        goodParam = GetComponent<GoodParam>();
        symbolIndex = goodParam.SymbolIndex;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Damager"))
            damageAction(gameObject);
    }
}
