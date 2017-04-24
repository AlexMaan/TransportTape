using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSpeedUpDown : MonoBehaviour {

    public float buttonStep = 0.2f;    

    public void TapeSpeedUp() {
        TapeManager.tapeSpeed += buttonStep;
    }

    public void TapeSpeedDown(){
        TapeManager.tapeSpeed -= buttonStep;
    }
}
