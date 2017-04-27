using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapeSpeedPause : MonoBehaviour {

    Button buttonPause;
    TapeManager tapeManager;
    public static int pauseButtonCounter;
    public int enableCounter;

	void Start () {
        tapeManager = FindObjectOfType<TapeManager>();
        buttonPause = GetComponent<Button>();
        buttonPause.interactable = false;
	}

    private void Update() {
        if (pauseButtonCounter > enableCounter) {
            buttonPause.interactable = true;
        }
    }

    public void PauseTapeClick() {
        tapeManager.StartCoroutine("PauseTape");
    }
}
