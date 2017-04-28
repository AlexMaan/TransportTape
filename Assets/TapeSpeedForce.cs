using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapeSpeedForce : MonoBehaviour {
    	
    TapeManager tapeManager;
    Button buttonForce;  

    void Start(){
        buttonForce = GetComponent<Button>();
        buttonForce.interactable = false;
        Invoke("ActivateButton", 3);
        tapeManager = FindObjectOfType<TapeManager>();        
    }

    public void ForceTapeClick() {
        TapeSpeedPause.pauseButtonCounter++;
        buttonForce.interactable = false;
        Invoke("ActivateButton", 3);
        tapeManager.StopCoroutine("ForceTape");
        tapeManager.StartCoroutine("ForceTape");
    }

    void ActivateButton() {
        buttonForce.interactable = true;
    }
}
