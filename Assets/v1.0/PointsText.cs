using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsText : MonoBehaviour {

    public Text uiText;

    void Update(){
        uiText.text = "Points: " + TapeManager.points.ToString();
    }
}
