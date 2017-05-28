using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignText : MonoBehaviour {

    public Text text;
    public GameObject win;
    public GameObject lose;

    void Awake() {
        ProgressWheel.roundIsEnded += DisplayText;
        text.gameObject.SetActive(false);
    }

    void DisplayText(int roundResult) {
        text.gameObject.SetActive(true);
        if (roundResult == 1) { /*text.text = "You Win !";*/ lose.SetActive(false); }
        else { /*text.text = "Round Over";*/ win.SetActive(false); }
    }
}
