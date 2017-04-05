using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresText : MonoBehaviour {

    public Text text;

    private void Awake(){
        text.text = TapeManager.points.ToString();
    }
}
