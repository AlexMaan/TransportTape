using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    GameManager gameManager;
    public static float tapeSpeed;
    public static int points = 0;
    public static CubeObjectPrim lastClickedObj;

    public float baseSpeed;
    public int roundTime;

    void Awake(){
     //singleton
        if (gameManager == null) gameManager = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        //
        tapeSpeed = baseSpeed;
    }

    void Update(){
        //tapeSpeed = baseSpeed;
    }
}
