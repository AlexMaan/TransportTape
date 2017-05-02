using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiViewer : MonoBehaviour {

    TextMesh textMesh;
    HoldSlot holdSlot;
    public int indexN;
    string text;

    private void Awake() {
        textMesh = GetComponent<TextMesh>();
        holdSlot = FindObjectOfType<HoldSlot>();
    }

    private void Update() {
        if (holdSlot.holdingGoods.Count > indexN && holdSlot.holdingGoods[indexN] != null) {
            text = holdSlot.holdingGoods[indexN].ToString();            
        }
        else text = "empty";
        

        textMesh.text = text;
    }
}
