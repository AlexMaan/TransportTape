using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeSpeedForce : MonoBehaviour {
    	
    TapeManager tapeManager;    

    void Start(){
        tapeManager = FindObjectOfType<TapeManager>();        
    }

    public void ForceTapeClick() {
        TapeSpeedPause.pauseButtonCounter++;
        tapeManager.StartCoroutine("ForceTape");
    }
}
