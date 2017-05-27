using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeManager : MonoBehaviour {

    TapeManager gameManager;
    public static float tapeSpeed;
    public static int points = 0;
    //public static CubeObjectPrim lastClickedObj;

    public float viewSpeed;
    public float baseSpeed;
    public float speedUpK;
    public int speedMode = 1; 
    public int roundTime;
    public float pauseTime;

    void Awake() {
        if (PlayerPrefs.HasKey("setupStartSpeed")) baseSpeed = float.Parse(PlayerPrefs.GetString("setupStartSpeed"));
        if (PlayerPrefs.HasKey("setupSpeedProgress")) speedUpK = float.Parse(PlayerPrefs.GetString("setupSpeedProgress"));
        //singleton
        //if (gameManager == null) gameManager = this;
        //else Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
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
        float timeStamp = 6;
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
        float stampSpeed = tapeSpeed;
        while (tapeSpeed >= stampSpeed * 0.2f) { tapeSpeed *= 1 - 3 * Time.deltaTime; yield return null; }
        tapeSpeed = stampSpeed * 0.2f;
        yield return new WaitForSeconds(pauseTime);
        while (tapeSpeed <= stampSpeed) { tapeSpeed *= 1 + 3 * Time.deltaTime; yield return null; }
        tapeSpeed = stampSpeed;
    }

    IEnumerator ForceTape() {
        float stampSpeed = tapeSpeed;
        while (tapeSpeed <= stampSpeed * 10f) { tapeSpeed *= 1 + 5 * Time.deltaTime; yield return null; }
        tapeSpeed = stampSpeed * 10f;
        yield return new WaitForSeconds(0.7f);
        while (tapeSpeed >= stampSpeed) { tapeSpeed *= 1 - 5 * Time.deltaTime; yield return null; }
        tapeSpeed = stampSpeed;
    }


}
