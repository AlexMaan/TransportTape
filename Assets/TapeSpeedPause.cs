using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapeSpeedPause : MonoBehaviour {

    Button buttonPause;
    TapeManager tapeManager;
    public static float pauseButtonCounter;
    public int enableCounter;

	void Start () {
        tapeManager = FindObjectOfType<TapeManager>();
        buttonPause = GetComponent<Button>();
        buttonPause.interactable = false;
	}

    private void Update() {
        if (pauseButtonCounter > enableCounter)  buttonPause.interactable = true;
        else buttonPause.interactable = false;
    }

    public void PauseTapeClick() {
        pauseButtonCounter = 0;
        tapeManager.StopCoroutine("PauseTape");
        tapeManager.StartCoroutine("PauseTape");
    }
}
