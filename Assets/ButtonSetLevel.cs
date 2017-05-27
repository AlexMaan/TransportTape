using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSetLevel : MonoBehaviour {

    public string numberRow;
    public string Shapes;
    SetupSettings settings;

    void Awake() {
        settings = FindObjectOfType<SetupSettings>();
    }

    public void SetLevelSettings() {
        settings.InputNumberRow.text = numberRow;
        settings.InputShapes.text = Shapes;
    }
}
