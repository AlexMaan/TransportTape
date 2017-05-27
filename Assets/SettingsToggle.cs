using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsToggle : MonoBehaviour {

    public GameObject settingsParent;
    public Vector3 posUp;
    public Vector3 posDown;
    int i = 1;

    public void ToggleSettings() {
        Vector3 vector = i == 1 ? posUp : posDown;
        settingsParent.transform.Translate(vector);
        i = -i;
    }
}
