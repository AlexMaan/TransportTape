using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeManager : MonoBehaviour {

    TapeManager gameManager;
    public static float tapeSpeed;
    public static int points = 0;
    public static CubeObjectPrim lastClickedObj;

    public float viewSpeed;
    public float baseSpeed;
    public float speedUpK;
    public int speedMode = 1; 
    public int roundTime;

    void Awake(){
     //singleton
        if (gameManager == null) gameManager = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        //
        tapeSpeed = baseSpeed;
        StartCoroutine("TapeSpeedProgress");
    }
        
    IEnumerator TapeSpeedProgress() {
        while(speedMode == 1) {
        tapeSpeed += speedUpK * Time.deltaTime;
            yield return null;
        }
    }

    
    void Update() {
        viewSpeed = tapeSpeed;
    }
}
