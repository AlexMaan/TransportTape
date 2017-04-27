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

    void Awake() {
     //singleton
        if (gameManager == null) gameManager = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        //
        tapeSpeed = baseSpeed;
        StartCoroutine("TapeSpeedProgress");
        StartCoroutine("TapeSdeepStartBoost");
    }

    void Update() {
        viewSpeed = tapeSpeed;
    }

    IEnumerator TapeSpeedProgress() {
        while(speedMode == 1) {
        tapeSpeed += speedUpK * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator TapeSdeepStartBoost() {
        float timeStamp = 10;
        float startSpeed = tapeSpeed;
        while (timeStamp > 0){
            tapeSpeed = startSpeed + timeStamp;            
            timeStamp -= Time.deltaTime * 3;
            if (timeStamp < 0) timeStamp = 0;
            yield return null;
        }
        tapeSpeed = startSpeed;
    }

    IEnumerator PauseTape() {
        print("pause!");
        yield return null;
    }

    IEnumerator ForceTape() {
        print("force!!!");
        yield return null;
    }


}
