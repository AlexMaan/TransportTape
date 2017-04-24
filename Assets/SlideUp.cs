using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideUp : MonoBehaviour {

    HelpSlot helpSlot;

    void Awake() {
        helpSlot = FindObjectOfType<HelpSlot>();
    }

    public void HelpSlotCompare() {
        if (ClickPicker.active != null)
        helpSlot.CompareWithHelpSlot(ClickPicker.active.gameObject);
    }
}
